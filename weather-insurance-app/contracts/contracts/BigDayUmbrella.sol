pragma solidity >=0.4.24 <0.6.0;

contract BigDayUmbrella {

    // Events
    event IssueClaim(address insurant, string reason);
    event DeclineClaim(address insurant);
    event PolicySubmitted(int lat, int lon, uint periodStart, uint periodEnd, address insurant);

    struct measure {
        uint256 Min;
        uint256 Max;
        bool IsSet;
    }

    enum weatherConditions { Sunny, Windy, Thunderstorm }
    enum measuredConditions { Temperature, WindSpeed, WindGustSpeed, UVIndex, Pressure, Humidity }

    int256 public Lat;
    int256 public Lon;
    uint256 public PeriodStart;
    uint256 public PeriodEnd;
    weatherConditions[3] public AllowedConditions;
    measure[6] public Measures;

    // Data structure of state of smart-contract
    enum StateType { Initial, WaitingWeatherUpdate, ClaimApproved, ClaimDeclined }
    StateType public State;

    // Roles
    address public Insurant;
    address public Oracle;

    constructor(address oracle, address insurant) public
    {
        Insurant = insurant;
        Oracle = oracle;
        State = StateType.Initial;
    }

    // Methods to change policy

    modifier canChangePolicy {
        require(State == StateType.Initial, "Policy was submitted.");
        require(msg.sender == Insurant, "Only insurant can update and submit policy.");
        _;
    }

    function submitPolicy(int256 lat, int256 lon, uint256 start, uint256 end) public canChangePolicy {

        require(end > start);
        require(start > now);
        require(start > 0);
        
        // Lat: [-85.05115, 85.05115] 
        require(lat >= -850511500 && lat <= 850511500);
        // Lon: [-180, 180] 
        require(lon >= -1800000000 && lon <= 1800000000);

        Lat = lat;
        Lon = lon;
        PeriodStart = start;
        PeriodEnd = end;

        uint isSetMeasures = 0;
        for (uint index = 0; index < Measures.length; index ++) {
            if (Measures[index].IsSet) {
                isSetMeasures += 1;
            }
        }
        require(isSetMeasures > 0);

        State = StateType.WaitingWeatherUpdate;
        emit PolicySubmitted(Lat, Lon, PeriodStart, PeriodEnd, Insurant);
    }

    function setPolicyMeasuredValue(measuredConditions measureType, uint minValue, uint maxValue) public canChangePolicy {
        require(maxValue > minValue);
        require(int(measureType) >= 0);
        require(measureType <= measuredConditions.Humidity);

        Measures[uint(measureType)] = measure(minValue, maxValue, true);
    }

    function getPolicyMeasuredValue(measuredConditions measureType) public view returns (uint256 minValue, uint256 maxValue, bool isSet) {
        require(int(measureType) >= 0);
        require(measureType <= measuredConditions.Humidity);

        measure memory values = Measures[uint(measureType)];
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

    function updateMeasuredConditions(measuredConditions measureType, uint value, uint timestamp) public canUpdateConditions {

        require(timestamp > PeriodStart);
        
        if (timestamp > PeriodEnd) {
            State = StateType.ClaimDeclined;
            emit DeclineClaim(Insurant);
            return;
        }
        
        require(uint(measureType) >= 0);
        require(uint(measureType) <= uint(measuredConditions.Humidity));

        measure memory values = Measures[uint(measureType)];
        if (values.IsSet && (values.Min > value || values.Max < value)) {
            if (measureType == measuredConditions.Temperature) {
                emit IssueClaim(Insurant, "Temperature limits exceeded");
            } else if (measureType == measuredConditions.WindSpeed) {
                emit IssueClaim(Insurant, "Wind speed limits exceeded");
            } else if (measureType == measuredConditions.WindGustSpeed) {
                emit IssueClaim(Insurant, "Wind gust speed limits exceeded");
            } else if (measureType == measuredConditions.UVIndex) {
                emit IssueClaim(Insurant, "UV index limits exceeded");
            } else if (measureType == measuredConditions.Pressure) {
                emit IssueClaim(Insurant, "Pressure limits exceeded");
            } else if (measureType == measuredConditions.Humidity) {
                emit IssueClaim(Insurant, "Humidity limits exceeded");
            }

            State = StateType.ClaimApproved;
        }
    }
    
}