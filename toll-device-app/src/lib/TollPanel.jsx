import React from "react";
import config from "../config.json";

const zoneToIndexMap = {'A': 0, 'B': 1, 'C': 2};

class TollPanel extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      loading: false,
      log: `will be reporting some car\n...if we can catch it\n...click the bounty hunter to catch car.`
    };
  }

  // Is the app loading?
  //
  // @param {boolean} value 
  setLoading = (value) => {
    this.setState({ loading: value });
  };

  report = async () => {
    this.setLoading(true);
    let addressForLog = this.props.carAddress.slice(0, 4) + '..' + this.props.carAddress.slice(-2);
    try {
      if (!window.web3 || !window.web3.eth) {
        throw '"Toll Bounty App" needs valid web3.js wallet.';
      }
      var currentAccounts = await web3.eth.getAccounts();
      if (!currentAccounts) {
        throw '"Toll Bounty App" needs valid account in web3.js wallet.';
      }
      var currentAddress = (currentAccounts && currentAccounts.length > 0) ? currentAccounts[0] : null;
      if (!currentAddress) {
        throw `"Toll Bounty App" couldn't extract address from web3.js wallet.`;
      }
      this.log('using address: ' + currentAddress);
      var currentNetwork = (await web3.eth.net.getNetworkType());
      if (!currentNetwork || currentNetwork !== 'rinkeby') {
        throw `"Toll Bounty App" requires web3.js wallet to be on the Rinkeby testnet.`;
      }
      const contract = new web3.eth.Contract(config.abi, config.ethereumContractAddress);
      let stake = await contract.methods.minStakeValue().call();
      this.log('seconds before bounty expires: ' + await contract.methods.bountyTimePeriodSeconds().call());
      this.log('minimum stake value: ' + stake);
      this.log('bounty reward value: ' + await contract.methods.rewardValue().call());
      this.log(`calling doReport on car ${addressForLog} @ (${this.props.hunterCoordsX},${this.props.hunterCoordsY})`);
      this.props.doHint('tollAppDoReport');
      await new Promise((resolve, reject) => {
        contract.methods.doReport(
          this.props.carAddress, 
          this.props.hunterCoordsX, 
          this.props.hunterCoordsY, 
          zoneToIndexMap[this.props.hunterCoordsZone])
          .send({from: currentAddress, value: stake})
        .on('confirmation', (confirmationNumber, receipt) => {
          if (confirmationNumber == 1) {
            this.log('\n+--------------+\n| CAR REPORTED |\n+--------------+\n');
            this.log(`car ${addressForLog} reported @ (${this.props.hunterCoordsX},${this.props.hunterCoordsY})`);
          }
          resolve();
        })
        .on('error', (error) => {
          console.log('display error :: ' + new String(error));
          this.log('\n+---------------+\n| REPORT DENIED |\n+---------------+\n');
          resolve();
        });
      });
    } catch (e) {     
      this.props.setError(new String(e));
    }

    this.setLoading(false);
    this.props.doHint(null);
  };

  // add a log line
  log = (line) => {
    this.setState({ log: `${line}\n${this.state.log}` });
  }

  render() {
    return (
      <div className={`ui segment ${this.state.loading ? "loading" : ""} black`}>
        <img src="assets/pin.png" style={{ top: "5px", right: "5px", width: "40px", position: "absolute", zIndex: "5" }}></img>
        <div className="ui grid">
          <div className="row centered">
            <h2 className="ui header">
              <div className="content">
                <i>Toll Bounty App</i>
              </div>
              <a onClick={() => this.props.doHint('tollApp')} style={{cursor: "pointer", marginLeft: "10px"}}><i className="info circle icon"></i></a>
            </h2>
          </div>
          <div className="row centered">
            <div className="twelve wide column">
              <div className={`ui primary ${this.props.atCar ? "" : "disabled"} button`} style={{ width: "90%" }} onClick={() => this.report()}>
                check and report
              </div>
              <a onClick={() => this.props.doHint('tollAppReportButton')} style={{ cursor: "pointer", marginLeft: "5px", float: "right" }}><i className="info circle icon"></i></a>              
            </div>
          </div>
          <div className="row centered">
            <div className="twelve wide column">
              <textarea rows="10" readOnly style={{ width: "100%", fontFamily: "monospace", fontSize: "x-small", backgroundColor: "#F0F0F0"}} value={this.state.log} onChange={() => {}}></textarea>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default TollPanel;