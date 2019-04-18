# Reservation Approval and Assignment on the Blockchain with Attestation and Location

## Files

1. Asset.sol smart contract
2. PowerPoint with screenshots

---

## Asset example

./Asset.sol

- State
  - StateType State;    //reserved or available
  - string Description; //asset description
  - address Owner;
  - address ReservedBy;
  - uint ReservedOn;
  - uint ReservedDays;
  - uint Longitude;
  - uint Latitude;

- Methods

  - Reserve(reserveFor, numberOfDays, latitude, longitude)
     - must be Owner of the Asset

  - ReleaseReservation()

     - until the Reservation is complete, only the Reservation holder can release the reservation

---

### Creating Microsoft Flow to automate Ethereum, triggered by PowerApp

1. Create a Flow with a PowerApp Trigger
2. Create "Initialize Variable" action
2. Name the Action "MyInput", and set type to String
3. Focus in the Value box, and the dialog menu will open
4. Click the "See More" link under the search box (on the right).
5. Click the "Ask in PowerApps" link - this will create a variable with the name of the "MyInput_Value"
6. (For ease of use) add additional "Initializer Variable" for each property you are going to send from PowerApps, using expression:

        json(variables('MyInput_Value')).subProperty1

7. Make sure you either pass the blockchain address for the Product and the User from the PowerApp, or use the ProductId and UserEmail to call another datasource or blockchain to lookup the appropriate addresses
8. Add the Ethereum Connector, add the ABI for Asset.sol, add the Product's address, and select the Reserve method

---

## Create the PowerApp to trigger the Microsoft Flow

  1. Start with the Asset Checkout sample
  2. From any event, click Action / Flows and add the Flow you previously created
  3. Find the screen with the Reserve button, and edit the event. 
  4. Make sure you have all the necessary properties, formatted as a JSON string
  5. Execute the [FlowApp].Run([JSON_String_With_Required_Params])

        MyFlow.Run("{ ""prop1"": ""value2"" }");

---

See the Powerpoint for screenshots