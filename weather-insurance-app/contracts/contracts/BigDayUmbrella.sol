pragma solidity ^0.4.24;

contract BigDayUmbrella {

    // Events
    event IssueClaim(address insurant, string reason);
    event DeclineClaim(address insurant);
    event PolicySubmitted(uint lat, uint lon, uint periodStart, uint periodEnd, address insurant);

    // Data structures for policy
    struct location {
        uint256 lat;
        uint256 lon;
    }

    struct measure {
        uint256 Min;
        uint256 Max;
        bool IsSet;
    }

    enum weatherConditions { Sunny, Windy, Thunderstorm }
    enum measuredConditions { Temperature, WindSpeed, WindGustSpeed, UVIndex, Pressure, Humidity, END }

    struct policy {
        location Location;
        uint256 PeriodStart;
        uint256 PeriodEnd;        
        weatherConditions[3] AllowedConditions;
        measure[6] Measures;
    }

    policy public Policy;

    // Data structure of state of smart-contract
    enum StateType { Initial, WaitingWeatherUpdate, ClaimApproved, ClaimDeclined }
    StateType public State;

    // Roles
    address public Insurant;
    address public Oracle;

    constructor(address oracle) public
    {
        Insurant = msg.sender;
        State = StateType.Initial;
        Oracle = oracle;
    }

    // Methods to change policy

    modifier canChangePolicy {
        require(State == StateType.Initial, "Policy was submitted.");
        require(msg.sender == Insurant, "Only insurant can update and submit policy.");
        _;
    }

    function submitPolicy() public canChangePolicy {
        require(Policy.Location.lat > 0);
        require(Policy.Location.lon > 0);
        require(Policy.PeriodStart > 0);
        require(Policy.PeriodEnd > Policy.PeriodStart);

        uint isSetMeasures = 0;
        for (uint index = 0; index < Policy.Measures.length; index ++) {
            if (Policy.Measures[index].IsSet) {
                isSetMeasures += 1;
            }
        }
        require(isSetMeasures > 0);

        State = StateType.WaitingWeatherUpdate;
        emit PolicySubmitted(Policy.Location.lat, Policy.Location.lon, Policy.PeriodStart, Policy.PeriodEnd, Insurant);
    }

    function setPolicyLocation(uint256 lat, uint256 lon) public canChangePolicy {
        policy storage currentPolicy = Policy;
        currentPolicy.Location = location(lat, lon);
    }

    function getPolicyLocation() public view returns(uint256 lat, uint256 lon){
        lat = Policy.Location.lat;
        lon = Policy.Location.lon;
    }

    function setPolicyTimeframes(uint256 start, uint256 end) public canChangePolicy {
        require(end > start);
        require(start > now);
        require(start > 0);

        policy storage currentPolicy = Policy;
        currentPolicy.PeriodStart = start;
        currentPolicy.PeriodEnd = end;
    }

    function getPolicyTimeframes() public view returns (uint256 start, uint256 end) {
        start = Policy.PeriodStart;
        end = Policy.PeriodEnd;
    }

    function setPolicyMeasuredValue(measuredConditions measureType, uint minValue, uint maxValue) public canChangePolicy {
        require(maxValue > minValue);
        require(int(measureType) >= 0);
        require(measureType < measuredConditions.END);

        policy storage currentPolicy = Policy;
        currentPolicy.Measures[uint(measureType)] = measure(minValue, maxValue, true);
    }

    function getPolicyMeasuredValue(measuredConditions measureType) public view returns (uint256 minValue, uint256 maxValue, bool isSet) {
        require(int(measureType) >= 0);
        require(measureType < measuredConditions.END);

        measure memory values = Policy.Measures[uint(measureType)];
        minValue = values.Min;
        maxValue = values.Max;
        isSet = values.IsSet;
    }

    // Methods to update weather conditions

    modifier canUpdateConditions {
        require(State == StateType.WaitingWeatherUpdate, "Policy wasn't submitted.");
        require(msg.sender == Oracle, "Only oracle can submit current weather conditions.");
        _;
    }

    function updateMeasuredConditions(uint measureType, uint value, uint timestamp) public canUpdateConditions {

        require(timestamp > Policy.PeriodStart);
        
        if (timestamp > Policy.PeriodEnd) {
            State = StateType.ClaimDeclined;
            emit DeclineClaim(Insurant);
            return;
        }
        
        require(measureType >= 0);
        require(measureType < uint(measuredConditions.END));

        measure memory values = Policy.Measures[uint(measureType)];
        if (values.IsSet && (values.Min > value || values.Max < value)) {
            if (measureType == uint(measuredConditions.Temperature)) {
                emit IssueClaim(Insurant, "Temperature limits exceeded");
            } else if (measureType == uint(measuredConditions.WindSpeed)) {
                emit IssueClaim(Insurant, "Wind speed limits exceeded");
            } else if (measureType == uint(measuredConditions.WindGustSpeed)) {
                emit IssueClaim(Insurant, "Wind gust speed limits exceeded");
            } else if (measureType == uint(measuredConditions.UVIndex)) {
                emit IssueClaim(Insurant, "UV index limits exceeded");
            } else if (measureType == uint(measuredConditions.Pressure)) {
                emit IssueClaim(Insurant, "Pressure limits exceeded");
            } else if (measureType == uint(measuredConditions.Humidity)) {
                emit IssueClaim(Insurant, "Humidity limits exceeded");
            }

            State = StateType.ClaimApproved;
        }
    }
    
}