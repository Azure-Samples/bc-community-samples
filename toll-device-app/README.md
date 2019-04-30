Ethereal Toll Booth 
=================
Goals: The goal of this project is to allow payments between devices with a simlulation of a vehicle passing through a toll.

## Flow
1. We choose to create an online portal and registry for vihicle owners to register their `Plate` strings, the unique liscense plate identifier for their vehicle. This is how most toll systems work now, a rider loading up their "Account" and then using it to pay tolls. In this case, we accepot ETH and store a balance for the user. The online form can be used here: and connects using web3 to our private POA network, hosted on Microsft Azure.
2. After successfully filling out the form, our smart contract mints an ERC-721 token, which keeps track of the unique Plate string, the balance of the vihicle, and the owner. There are transfers and approvals for if a vehicle owners lets someone else use their car, or sells it.
3. We can easily integrate with existing camera systems on tolls today by using web requests to our server for facilitating payment between vehicles. When a camera picks up any plate string, they can simply send our server at --- a request containing the toll booth number (for user validation), the cost of the toll, and the plate string.
4. A request for payment is automatically generated through the smart contract.
5. The driver of the vehicle entering the toll recieves a notification at ---.  They have been requested to accept a toll of a certain amount and can confirm that they are at that toll booth easily. They can confirm payment without spending gas because we are using EC-recover to sign a validation.
6. Successful payments are emitted as events so everyone knows that the toll has been paid and the driver free to continue on there way to grandma's house.

## Implementation
You can connect to our private azure hosted ethereum network here: http://40.76.76.27:8501

You can register your plate and recieve an ERC-721 token using metamask or any web3 browser app here: https://ethereum-toll.glitch.me/tollbooth This webapp also includes payment verification notifications. 

## What we learned
I wasnt a fan of private blockchains, until we got a private POA network running on Azure. It was super exiting to see the blocks getting mined and coming in as we were testing and making trasfers. We follows [this]() guide, which had some phrasing issues and small mistakes (I made a pull request with some improvements [here](https://github.com/caleteeter/smartcontractdev/pull/2)). Geth was a lot easier than I thought to get running.

One of the biggest challenges I've struggled with as a blockchain engineer is making sure pick up all events off chain, so user experiences can be consistent and they dont need to know they are really using a blockchain.  So we decided to use Azure's Logic Apps to pick up all the payment request and payment success/failure messages, to connect to our user app.

We also used EC-recover for verifying signatures, for the first time and it was fun to try out these features in Solidity.
