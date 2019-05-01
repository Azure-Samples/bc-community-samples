# Truffle / Ganache

1. Run Ganache

1. from root, open command prompt

1. run "npm i"

1. Run "truffle migrate --reset" from the root of the project

1. contracts should be deployed:

- 1 GameStore
- 4 GameStoreItems

4. copy the GameStore address

5. go to browser and configure your local Ganache instance in MetaMask.

- Login as Account 1, and make sure you can switch to Account 2

# React

1. open command prompt at the /app folder

2. run "npm i"

3. run "npm run start"

4. open browser to the http://localhost:3000

5. when you perform some actions, MetaMask will ask you to allow login / approve

6. Make sure the GameStore Address from the contract is entered, and make sure the Account Address shown is the Ganache Account 1

7. All of the Contracts belong to Account 1 originally.

8. Make an item for sale by giving it a Price. Save the Price above 0 and approve via MetaMask

9. Now switch accounts to Account 2 in metamask.

10. Reload the site (possibly the browser)

11. Now you should see some items in ForSale, and all the items in All items.

12. Purchase an Item, and it should move to your item tab

13. Switch accounts and login as Account 1, to see the purchases.

14. Notice Account 1 now has an Amount stored in the GameStore Contract. Acccount 1 can request to transfer the collected funds.

# Unity

The unity project has both a Design time component and Runtime.

1. Start from the 2D tutorial

https://www.youtube.com/watch?v=4cF7Sl7FazE

3. Create a folder at:

- Assets/Resources/1GameStore/BCitems

2. Copy the custom scripts from /unity and put them in the 1GameStore folder

3. From Assets menu choose Assets/Create/GameStore Connection

This will create a connection. Update it with the correct GameStore properties

4. Test the connection.

5. Synchronize the assets. This will create files for each item

6. Add 1GameStore Panel to the scene and configure an item to open it.

7. Purchase items during the game
