. ~/.nvm/nvm.sh
nvm use stable
export NODE_PATH="`npm config get prefix`/lib/node_modules"
node -e "
Web3 = require('web3'); 
web3 = new Web3('http://116.203.118.82:8545/');
" -i --experimental-repl-await