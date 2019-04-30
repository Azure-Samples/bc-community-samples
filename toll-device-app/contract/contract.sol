pragma solidity ^0.4.25;

contract TollEnforce {

    address owner;
    
    uint public rewardValue = 100000000000000;                         // current reward in Wei when perpetrator nabbed by enforcer, paid out on GoodReport
    uint public minStakeValue = 100000000000000;                       // current bounty hunter stake in Wei for reporting perpetrator, returned on GoodReport or ExpiredReport
    uint public bountyTimePeriodSeconds = 30;                          // how many seconds--since report--a bounty is active for
    
    struct Report {                                                    // bounty report by hunter
        bool isPending;                                                // is report still pending reconciliation?
        address payable bountyHunter;                                  // address of hunter
        uint bountyExpirationUnixTime;                                 // Unix time seconds when bounty will timeout
        uint carXCoordinate;                                           // X coordinate of car on map
        uint carYCoordinate;                                           // Y coordinate of car on map
        uint stakedValue;                                              // bounty hunter's stake in Wei, returned on GoodReport or ExpiredReport
        uint rewardValue;                                              // bounty hunter's reward in Wei, paid out on GoodReport
    }
    
    mapping (address => Report) public reports;                        // all current reports: car address to report
    address[] public currentReports;                                   // addresses of all reports since last expiration run
    
    mapping (bytes32 => uint) public payeeHashToLastPaymentUnixTime;   // sha256 of payee `<address>@<imparterTag>` to last payment considered
    mapping (address => uint) public carToZoneATimeoutUnixTime;        // map when zone A permit expires for cars
    mapping (address => uint) public carToZoneBTimeoutUnixTime;        // map when zone B permit expires for cars
    mapping (address => uint) public carToZoneCTimeoutUnixTime;        // map when zone C permit expires for cars
    mapping (address => bytes32) public carToPlateHash;                // map license plate (sha256) for cars
    address[] public currentCars;                                      // list all cars tracked
    
    event Topup(address forCar, bytes32 byWhom, uint newZoneATimeout, uint newZoneBTimeout, uint newZoneCTimeout);

    event NewReport(address forCar, uint carXCoordinate, uint carYCoordinate, uint zoneIndex);
    event BadReport(address forCar);
    event GoodReport(address forCar);
    event ExpiredReport(address forCar);

    constructor() public {
        owner = msg.sender;
    }

    modifier isOwner() {
        require(owner == msg.sender);
        _;
    }

    // Validate hash for address
    // 
    // @param who - who signed
    // @param hash - of message: keccak256("\x19Ethereum Signed Message:\n", len(message), message)
    // @param v,r,s - signature tuple
    // @returns [true] if signature hash checks out for address
    function validate(address who, 
                      bytes32 hash, 
                      uint8 v, 
                      bytes32 r, 
                      bytes32 s) public view isOwner {
        require(ecrecover(hash, v, r, s) == who);
    }
    
    // setup admin values
    function admin(uint _rewardValue,
                   uint _minStakeValue,
                   uint _bountyTimePeriodSeconds) public isOwner {
        rewardValue = _rewardValue;
        minStakeValue = _minStakeValue;
        bountyTimePeriodSeconds = _bountyTimePeriodSeconds;
    }
  
    // @param source - 32 bytes
    // @param offset - e.g. 0, 4, 8 into source
    // @returns first 12 bytes split into 4 byte values
    // thanks https://ethereum.stackexchange.com/a/13162
    function split(bytes32 source, uint offset) private pure returns (bytes4 res) {
        assembly {
            let freemem_pointer := mload(0x40)
            mstore(add(freemem_pointer,0x00), source)
            res := mload(add(freemem_pointer,offset))
        }
    }
    
    // convert bytes to integer
    // thanks: https://ethereum.stackexchange.com/a/51234
    function bytesToUint(bytes4 b) private pure returns (uint256){
        uint256 number;
        for(uint i=0;i<b.length;i++){
            number = number + uint(uint8(b[i])*(2**(8*(b.length-(i+1)))));
        }
        return number;
    }      
  
    // @param forCar - which car the topup is for: validated earlier using 'validate' by owner
    // @param plateHash - hash of license plate
    // @param byWhom - who made the topup payment: sha256 hash with format `<address>@<imparterTag>` where imparterTag is as per ledgers.js
    // @param newZoneTimeoutsBytes - Unix time seconds when zone permits expire forCar:  32 byte hex string first 4 bytes: zonaA, next zoneB, next zoneC
    //
    // Note: if this code looks convoluted in places, it's adjustments to avoid 'stack too deep' errors
    function topup(address forCar, 
                   bytes32 plateHash,
                   bytes32 byWhom, 
                   bytes32 newZoneTimeoutsBytes) public isOwner {
        uint[] memory newZoneTimeouts = new uint[](3);
        newZoneTimeouts[0] = bytesToUint(split(newZoneTimeoutsBytes, 0));
        newZoneTimeouts[1] = bytesToUint(split(newZoneTimeoutsBytes, 4));
        newZoneTimeouts[2] = bytesToUint(split(newZoneTimeoutsBytes, 8));
        if (newZoneTimeouts[0] == 0 && newZoneTimeouts[1] == 0 && newZoneTimeouts[2] == 0) return;
        payeeHashToLastPaymentUnixTime[byWhom] = now;
        if (carToZoneATimeoutUnixTime[forCar] == 0
            && carToZoneBTimeoutUnixTime[forCar] == 0
            && carToZoneCTimeoutUnixTime[forCar] == 0) {
            // car not tracked yet
            currentCars.push(forCar);
        }
        if (carToZoneATimeoutUnixTime[forCar] < newZoneTimeouts[0]) carToZoneATimeoutUnixTime[forCar] = newZoneTimeouts[0];
        if (carToZoneBTimeoutUnixTime[forCar] < newZoneTimeouts[1]) carToZoneBTimeoutUnixTime[forCar] = newZoneTimeouts[1];
        if (carToZoneCTimeoutUnixTime[forCar] < newZoneTimeouts[2]) carToZoneCTimeoutUnixTime[forCar] = newZoneTimeouts[2];
        carToPlateHash[forCar] = plateHash;
        newZoneTimeouts[0] = carToZoneATimeoutUnixTime[forCar];
        newZoneTimeouts[1] = carToZoneBTimeoutUnixTime[forCar];
        newZoneTimeouts[2] = carToZoneCTimeoutUnixTime[forCar];
        emit Topup(forCar, byWhom, newZoneTimeouts[0], newZoneTimeouts[1], newZoneTimeouts[2]);
    }

    // @param forCar - which car to check
    // @returns Unix time seconds when zone A permit expires forCar
    function getZoneATimeout(address forCar) public view returns (uint) {
        return carToZoneATimeoutUnixTime[forCar];
    }
    
    // @param forCar - which car to check
    // @returns Unix time seconds when zone A permit expires forCar
    function getZoneBTimeout(address forCar) public view returns (uint) {
        return carToZoneBTimeoutUnixTime[forCar];
    }

    // @param forCar - which car to check
    // @returns Unix time seconds when zone A permit expires forCar
    function getZoneCTimeout(address forCar) public view returns (uint) {
        return carToZoneCTimeoutUnixTime[forCar];
    }
    
    // @param forCar - which car to check
    // @returns [true] of permitted
    function isPermittedInZoneA(address forCar) public view returns (bool) {
        if (carToZoneATimeoutUnixTime[forCar] == 0) return false;
        return carToZoneATimeoutUnixTime[forCar] > now;    
    }

    // @param forCar - which car to check
    // @returns [true] of permitted
    function isPermittedInZoneB(address forCar) public view returns (bool) {
        if (carToZoneBTimeoutUnixTime[forCar] == 0) return false;
        return carToZoneBTimeoutUnixTime[forCar] > now;    
    }

    // @param forCar - which car to check
    // @returns [true] of permitted
    function isPermittedInZoneC(address forCar) public view returns (bool) {
        if (carToZoneCTimeoutUnixTime[forCar] == 0) return false;
        return carToZoneCTimeoutUnixTime[forCar] > now;    
    }

    // msg.sender == bountyHunter
    // msg.value == stakedValue
    // @param carAddress - being reported
    // @param plateHash - being checked, if wrong, instant report
    // @param carXCoordinate - of car on map
    // @param carYCoordinate - of car on map
    // @param zoneIndex - 0 for zoneA, 1 for zoneB, 2 for zoneC, zone for coordinates 
    //   if zone mis-reported for coordinates; stakedValue will be lost upon reconciliation
    function doReport(address carAddress, 
                      bytes32 plateHash,
                      uint carXCoordinate,
                      uint carYCoordinate,
                      uint zoneIndex) public payable {
        require(msg.value >= minStakeValue);
        require(!reports[carAddress].isPending);
        if (carToPlateHash[carAddress] == plateHash) {
            // if bad plate hash, instant report, let enforcement officer deal with it, ticket regardless of payments
            if (zoneIndex == 0) require(carToZoneATimeoutUnixTime[carAddress] < now);
            if (zoneIndex == 1) require(carToZoneBTimeoutUnixTime[carAddress] < now);
            if (zoneIndex == 2) require(carToZoneCTimeoutUnixTime[carAddress] < now);
        }
        reports[carAddress] = Report(true, msg.sender, now + bountyTimePeriodSeconds, carXCoordinate, carYCoordinate, msg.value, rewardValue);
        currentReports.push(carAddress);
        emit NewReport(carAddress, carXCoordinate, carYCoordinate, zoneIndex);
    }

    // msg.sender == enforcer
    // @param carAddress - being reported
    // @param isGood - [true] if car found and ticketed
    //    A good report means:
    //    - reported car found at reported coordinates
    //    - reported coordinates do lie in reported zone (zone cannot be misreported)
    function reconcileReport(address carAddress,
                             bool isGood) public isOwner {
        require(reports[carAddress].isPending);  // report must exist
        if (isGood) {
            reports[carAddress].bountyHunter.send(reports[carAddress].stakedValue + reports[carAddress].rewardValue);        
            emit GoodReport(carAddress);
        } else {
            emit BadReport(carAddress);
        }
        delete reports[carAddress];  // remove report
    }

    // To be run periodically to expire reports.
    //
    // Cleans up reconciled and expired reports.
    function expireReports() public isOwner {
        uint newLength = 0;
        for (uint i = 0; i < currentReports.length; i++) {
            // reconciled
            if (!reports[currentReports[i]].isPending) {
                continue;
            }
            // expired
            if (reports[currentReports[i]].bountyExpirationUnixTime < now) {
                reports[currentReports[i]].bountyHunter.send(reports[currentReports[i]].stakedValue); // refund stake
                delete reports[currentReports[i]];
                emit ExpiredReport(currentReports[i]);
                continue;
            }
            // still pending report
            currentReports[newLength] = currentReports[i];
            newLength++;
        }
        // by now we removed all expired and reconciled reports
        currentReports.length = newLength;
    }

    // To be run periodically to purge cars
    function purgeCars() public isOwner {
        uint newLength = 0;
        for (uint i = 0; i < currentCars.length; i++) {
            if (carToZoneATimeoutUnixTime[currentCars[i]] > now 
                || carToZoneBTimeoutUnixTime[currentCars[i]] > now 
                || carToZoneCTimeoutUnixTime[currentCars[i]] > now) {
                currentCars[newLength] = currentCars[i];
                newLength++;
            } else {
                delete carToZoneATimeoutUnixTime[currentCars[i]];
                delete carToZoneBTimeoutUnixTime[currentCars[i]];
                delete carToZoneCTimeoutUnixTime[currentCars[i]];
                delete carToPlateHash[currentCars[i]];
            }
        }
        // by now we removed all expired cars-zone allotments
        currentCars.length = newLength;
    }

    // @returns number cars tracked: topped up since last purge
    function getNumberCurrentCars() public view returns (uint) {
      return currentCars.length;
    }

    // @returns number reports tracked: not resolved and not expired since last expiration run
    function getNumberCurrentReports() public view returns (uint) {
      return currentReports.length;
    }
} 