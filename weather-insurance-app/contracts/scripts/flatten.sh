#!/usr/bin/env bash

rm -rf ../flats
mkdir -p ../flats

../node_modules/.bin/truffle-flattener ../contracts/ForeignBridge.sol > ../flats/ForeignBridge_flat.sol
../node_modules/.bin/truffle-flattener ../contracts/HomeBridge.sol > ../flats/HomeBridge_flat.sol
../node_modules/.bin/truffle-flattener ../contracts/BridgeValidators.sol > ../flats/BridgeValidators_flat.sol
