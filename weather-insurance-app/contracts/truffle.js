module.exports = {
    // See <http://truffleframework.com/docs/advanced/configuration>
    // to customize your Truffle configuration!
    networks: {
        development: {
            host: '127.0.0.1',
            port: 8545,
            network_id: '*', // Match any network id
            gasPrice: 0
        }
    },
    solc: {
        optimizer: {
            enabled: true,
            runs: 200
        }
    },
    mocha: {
        reporter: 'eth-gas-reporter',
        enableTimeouts: false,
        reporterOptions : {
            currency: 'USD',
            gasPrice: 1
        }
    }
};