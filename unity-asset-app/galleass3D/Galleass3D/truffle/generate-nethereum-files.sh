 #!/bin/sh
 

#requires
# - dotnet
# - downloaded and build Netherem source code.

rm -r ./build/nethereum 2>/dev/null
dotnet-sdk.dotnet ~/github/Nethereum/src/Nethereum.Generator.Console/bin/Debug/netcoreapp2.1/Nethereum.Generator.Console.dll generate from-truffle -d ./build/contracts -o ./build/nethereum -ns Galleass3D.Contracts

rm -r ../Assets/Scripts/Contracts
mkdir -p ../Assets/Scripts/Contracts
cp -r ./build/nethereum/* ../Assets/Scripts/Contracts
