Weather insurance App for Azure Blockchain Workbench
=
Overview 
--
This application allows to insure weather conditions for your special day. You can insure not only weather but some more specific details, like: wind speed, temperature, humidity, etc.

Application Roles
--

| Name           | Description          |
| :------------- | :------------------- |
| Oracle         | It's account that is used by MSN weather to update weather info in the smart-contract |
| Insurant       | It's account that creates insurance claim and setup rules when claim could be issued |

States
--

| Name                      | Description          |
| :------------------------ | :------------------- |
| Initial                   | Indicates that Insurant must create policy for insurance claim, by specifyng measured conditions, weather conditions, location and time period|
| WaitingWeatherUpdate      | Indicates that oracle will submit weather updates, when oracle would submit information that violates policy created by insurant, insurance claim will be automatically issued, else after timeframe passed claim will be declined |
| ClaimApproved             | Indicates that claim was approved |
| ClaimDeclined             | Indicates that claim wasn't approved |

Workflow details
--
An instance of BigDayUmbrella application's workflow starts in initial state. Insurant must create policy. To create policy insurant must setup conditions for measured metrics like: Temperature, WindSpeed, WindGustSpeed, UVIndex, Pressure, Humidity, and specify minimum and maximum values for this measures.

Then insurant must specify weather conditions that he wants to insure. List of weather conditions:  Thunderstorm, RainSnow, Sleet, Icy, Showers, Rain, Flurries, Snow, Dust, Fog, Haze, Windy, Cloudy, MostlyCloudy, Sunny, MostlySunny, Hot, ChanceOfTStorm, ChanceOfRain, ChanceOfSnow

Then insurant must submit policy by specifying location (can be coordinates or name of place or region) and timeframes when policy is active.  

When policy is submitted logic app will update information about the weather in the specified location on behalf of Oracle's role. 

If weather submitted by oracle will violate created policy - insurance claim is automatically issued, in other case it will be declined after time period passed. 

Creation of logic app
--

Logic app source code is located in [recurrence_weather_update.txt](logic_apps/recurrence_weather_update.txt) file. To setup the application you should:

-	Create a blank logic app

-	Open the created app

-	Open `Logic app code view` and paste there the content from file: [recurrence_weather_update.txt](logic_apps/recurrence_weather_update.txt)

- 	Open `Logic app designer` and set your Oracle's email into `UserEmailAddress` variable

-	Save the changes


Logic app workflow:
--

-	The app runs the flow every 5 minute by first recurrence step

-	The app retrieves Oracle's ledgerIdentifier from which the app updates the weather info in the smart-contract

-	Runs sql procedure to retrieve all smart-contracts and their details where state equal: "WaitingWeatherUpdate"

-	Retrieve the weather conditions from MSN for each location that stored in the smart-contracts from previus step

-	Store the conditions to the appropriate smart-contract with help of Service Bus (Send Message) and Messaging API

All the weather conditions are sent as parallel requests.

Application files
--

1. [BigDayUmbrella.json](contracts/contracts/BigDayUmbrella.json)
2. [BigDayUmbrella.sol](contracts/contracts/BigDayUmbrella.sol)
3. [query.sql](sql/query.sql)
4. [recurrence_weather_update.txt](logic_apps/recurrence_weather_update.txt)