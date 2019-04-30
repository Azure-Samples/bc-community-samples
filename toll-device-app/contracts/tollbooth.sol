pragma solidity ^0.4.25;

contract ERC721Mintable {
    function ownerOf(uint a) public view returns(address);
    function mint(address to, uint256 tokenId) public returns (bool);
}

contract TollBooth {

 address public admin;
 address public ERC721Address;
 uint public vehicleCount;
 ERC721Mintable public tokenContract;


mapping (string => Vehicle) vehicles;
mapping (uint => string) tollBooth;

struct Vehicle {
    uint bal;
    string plate;
    uint tokenId;
}

constructor(address ERC721Contract) public {
  admin = msg.sender;
  ERC721Address = ERC721Contract;
  tokenContract = ERC721Mintable(ERC721Contract);
}

modifier onlyAdmin {
    require(msg.sender == admin);
    _;
}

function updateERC721Contract(address _address) public onlyAdmin {
  ERC721Address = _address;
}

function updateTollBooth(uint _boothNumber, string _location) public onlyAdmin {
    tollBooth[_boothNumber] = _location;
}

function registerVehicle(string _plate) public payable {
    require(vehicles[_plate].tokenId == 0);
    
    // Mint a new token
    tokenContract.mint(msg.sender, vehicleCount);

    // Create the new vehicle
    vehicles[_plate].bal = msg.value;
    vehicles[_plate].plate = _plate;
    vehicles[_plate].tokenId = vehicleCount;
    
    vehicleCount++;
    }

    function addBalance(string _plate) public payable {
        vehicles[_plate].bal += msg.value;
    }

    function getTollHash(uint _amount, uint _boothNumber, string _plate) public view returns (bytes32 tollHash){
     return sha256(_amount, _boothNumber, _plate);
    }

    function getVehicleOwner(string _plate) public view returns (address ownerAddress){
      return tokenContract.ownerOf(vehicles[_plate].tokenId);
    }

function verifySignedToll(uint _amount, uint _boothNumber, string _plate, bytes32 _tollHash, uint8 _v, bytes32 _r, bytes32 _s) view returns(address retAddr) {
    // Check that the tollHash is correct
    require(_tollHash == getTollHash(_amount, _boothNumber, _plate), "Toll hashes do not match");

    // Check the vehicle signed the toll
    address vehicleOwnerAddress = getVehicleOwner(_plate);
    address tollSignerAddress = ecrecover(_tollHash, _v, _r, _s);
    require (vehicleOwnerAddress == tollSignerAddress, "Signature doesn't match vehicle owner");
}

    function submitToll(uint _amount, uint _boothNumber, string _plate, bytes32 _tollHash, uint8 _v, bytes32 _r, bytes32 _s) public returns(bool){
        verifySignedToll(_amount, _boothNumber, _plate, _tollHash, _v, _r, _s);
        // subtract toll amount from balance
        require (vehicles[_plate].bal >= _amount, "Insufficient vehicle balance");
        vehicles[_plate].bal -= _amount;
        return true;
    }

// Helper functions

    function verify( bytes32 hash, uint8 v, bytes32 r, bytes32 s) public view returns(address retAddr) {
        retAddr= ecrecover(hash, v, r, s);
    }

  function stringToBytes32(string memory source) public pure returns (bytes32 result) {
      bytes memory tempEmptyStringTest = bytes(source);
      if (tempEmptyStringTest.length == 0) {
        return 0x0;
      }
      assembly {
        result := mload(add(source, 32))
      }
    }
}
