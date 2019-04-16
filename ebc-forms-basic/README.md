In this example we will take data from a Microsoft Form and use the Ethereum Blockchain Connector in an Azure Logic App to save it with an Ethereum smart contract.

 * Create a [Simple Ethereum POA network on Azure](https://github.com/caleteeter/smartcontractdev/blob/master/example1-setup.md), or you can use an existing network.
 * Deploy the NameRegistry.sol contract from this repository to the ethereum network. One method is to use [Remix](http://remix.ethereum.org/) with [Metamask](https://metamask.io/)
    * Import an account to Metamask from the network created in the previous step (Account blockie -> "Import Account")
    * Add the network in Metamask using "Custom RPC" from the network drop-down.
    * Paste the contract in Remix.
    * Select the "Run" tab in Remix, select "Injected Web3" for the environment. 
    * Click the pink "Deploy" button below, then approve the transaction in the Metamask popup.
 * Create an Office 365 developer account and assign yourself an Office 365 Enterprise E3 Developer license.
 * Duplicate this Microsoft Form: https://forms.office.com/Pages/ShareFormPage.aspx?id=b5h3Q4KJsUGFVjXBvjLTYsc-I1abSlhPhiT6G3Pupz5URExOVFRXRzhKN0ZXNTFCTjE4UDYzMDFGTC4u&sharetoken=izSuFYz2Wk1a7f3wZ7Iy
 * Create a new logic app in Azure Portal; Create resource -> Logic App.
 * Choose the blank logic app template.
 * Search for the "Microsoft Forms" connector and choose the "When a new response is submitted" trigger.
     * When prompted, login to the account used to duplicate the form.
     * Select the form in the "Form Id" drop-down.
 * Click "New Step", select the "Get response details" action.
     * Select the form in the "Form Id" drop-down.
     * Choose "Add dynamic content" for the "Response Id" input, and then select "List of response notifications Response Id"
 * Click "New Step" within the For each block that auto-created for you; select the Ethereum Blockchain Connector. Input the connection parameters. Choose "Execute smart contract function" from the actions tab.
    * Input the contract ABI. In Remix go to the "Compile" tab and click the copy ABI button under the contract selection drop-down.
    * Input the contract address. In Remix go to the "Run" tab and click on your contract in the "Deployed Contracts" section.
    * Input the contract function. Choose "Set Nickname" from the drop-down.
    * Configure the "addr" parameter. Select "Add dynamic content", choose "Answer to the question above" for the first question from our form. i.e. "Please enter an ethereum address:"
    * Configure the "nickname" parameter. Select "Add dynamic content", choose "Answer to the question above" for the second question from our form. i.e. "Please enter a name to associate with this address::"
* Click "Run" and to test out your new Logic App. I hope this example has inspired you with many possibilities for using the Ethereum Blockchain Connector in your Azure Logic Apps.