# Galleass3D

A Ethereal Hackaton Project.
Submitted by  Surfing Nerd (thomas.haller@lab10.coop)
Gitcoin Bounty: https://gitcoin.co/issue/Azure-Samples/bc-community-samples/15/2844

More about the Hackathon:
https://medium.com/gitcoin/the-ethereal-hackathon-4f5dc2eb56d6


## About

This is a Proof of Concept, learning and teaching project for Ethereum, Smart Contracts, Unity .Net and C#.
It is a fischerman themed ressource harvesting game, 
originally developed by Austin Thomas Griffith https://github.com/austintgriffith/galleass

See also this Medium Article
https://medium.com/@austin_48503/galleass-io-development-update-july-18-7f08c112de64

For the Ethereal  Hackaton 2019 i decided to remake the game in Unity3D, using Nethereum as connector to a private, specialized blockchain.

### Unity

Unity 2019.3.13f1 has been used on Ubuntu 18.04 for development.
In order to get Nethereum completly supporte .Net 4.x as scripting backend is beeing used.

Unfortuonatly the project wont run within a Web Browser (JS/WebAssembly/OpenGL Build) because of the heavy use of async functions. Maybe the Unity Dev Team manage to make this magic happen in the future.

###  truffle

Within the subdirectory "truffle" there is a truffle project with the smart contracts of Galleass3D,
including deployment scripts.
versions used:

- node v11.1.0
- Truffle v5.0.14
- Solidity v0.4.25
- NPM v6.4.1


A Truffle project.

`npm i`
