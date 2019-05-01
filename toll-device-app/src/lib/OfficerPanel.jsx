import React from "react";
import config from "../config.json";

const zoneToIndexMap = { 'A': 0, 'B': 1, 'C': 2 };

class OfficerPanel extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      message: 'idle',
      loading: false,
      log: `waiting for car report\n...will come in via Ethereum event\n...we'll read it from Azure.`,
      previousCar: null,
      previousX: null,
      previousY: null
    };
  }

  // Is the app loading?
  //
  // @param {boolean} value 
  setLoading = (value) => {
    this.setState({ loading: value });
  };

  // add a log line
  log = (line) => {
    this.setState({ log: `${line}\n${this.state.log}` });
  }

  componentDidMount() {
    setInterval(this.poll, 10000); // poll for events every 10 seconds
  }

  /**
   * Poll for dispatch events from Azure
   */
  poll = async () => {
    this.setState({message: "polling"});
    try {
      let result = await fetch(config.poll__AzureURL.replace('{atCar}', this.props.carAddress.toLowerCase()), {
        method: "GET",
        headers: { "Content-Type": "application/json; charset=utf-8" }
      })
      .then(response => {
        if (response.status == 200) {
          return response.json()
        } else {
          return response.text().then(error => { throw error });
        }
      });
      if (result.forCar) {
        if (this.state.previousCar != result.forCar 
            || this.state.previousX != result.carXCoordinate
            || this.state.previousY != result.carYCoordinate) {
          this.ticket(result.forCar, result.carXCoordinate, result.carYCoordinate, result.zoneIndex);
          this.props.enforcementCoordsSetterFn(result.carXCoordinate, result.carYCoordinate);
        }
        this.setState({ previousCar: result.forCar, previousX: result.carXCoordinate, previousY: result.carYCoordinate});
      }
    } catch (e) {
      this.props.setError(new String(e));
    }

    this.setState({message: 'idle'});
  };

  /**
   * Issue ticket or collect stake.
   */
  ticket = async (reportedCar, reportedX, reportedY, reportedZoneIndex) => {
    this.setState({message: "responding"});
    this.log("responding to dispatch, 'toll-enforce-poll' Azure Logic App gave result");
    this.log(`driving to (${reportedX},${reportedY})`);
    console.log(`checking car: ${this.props.carCoordsX},${this.props.carCoordsY}`);
    setTimeout(
      async () => {
      let zoneIndex = zoneToIndexMap[this.props.carCoordsZone];
        let isDispatchGood = (this.props.carCoordsX
          && this.props.carCoordsX == reportedX
          && this.props.carCoordsY == reportedY
          && zoneIndex == reportedZoneIndex
          && reportedCar.toLowerCase() == this.props.carAddress.toLowerCase());
      if (isDispatchGood) {
        this.log(`good dispatch at (${reportedX},${reportedY})`);
      } else {
        this.log(`bad dispatch at (${reportedX},${reportedY})`);
      }
      try {
        this.log(`\nUsing 'toll-enforce-reconcile' Azure Logic App to reconcile report using 'reconcileReport' in Ethereum contract.\n`);
        await fetch(config.reconcile__AzureURL, {
          method: "POST",
          headers: { "Content-Type": "application/json; charset=utf-8" },
          body: JSON.stringify({
            contractAddress: config.ethereumContractAddress,
            carAddress: this.props.carAddress,
            isGood: isDispatchGood
          })
        })
        .then(response => {
          if (response.status != 200) {
            response.text().then(error => { throw error });
          }
        });
        if (isDispatchGood) {
          this.log('\n+--------------+\n| CAR TICKETED |\n+--------------+\n');
        } else {
          this.log('\n+-----------------------------------+\n| INCORRECT REPORT, STAKE GARNISHED |\n+-----------------------------------+\n');
        }
        
      } catch (e) {
        this.props.setError(new String(e));
      }
      this.setState({ message: 'idle' });      
    }, config.animationTimeSeconds * 1000);
  }

  /**
   * Run admin workflow on Azure.
   */
  admin = async () => {
    this.setLoading(true);
    try {
      this.props.doHint('enforcementAppAdmin');
      this.log('calling admin workflow on Azure');
      let result = await fetch(config.admin__AzureURL, {
        method: "POST",
        headers: { "Content-Type": "application/json; charset=utf-8" },
        body: JSON.stringify({
          contractAddress: config.ethereumContractAddress
        })
      })
      .then(response => {
        if (response.status == 200) {
          return response.json()
        } else {
          return response.text().then(error => { throw error });
        }
      });
      this.log('# cars before cleanup: ' + result.beforeNumCars);
      this.log('# reports before cleanup: ' + result.beforeNumReports);
      this.log('# cars after cleanup: ' + result.afterNumCars);
      this.log('# reports after cleanup: ' + result.afterNumReports);
    } catch (e) {
      this.props.setError(new String(e));
    }

    this.setLoading(false);
    this.props.doHint(null);
  };

  render() {
    return (
      <div className={`ui segment ${this.state.loading ? "loading" : ""} black`}>
        <img src="assets/handcuffs.png" style={{ top: "5px", right: "5px", width:"50px", position: "absolute", zIndex: "5" }}></img>
        <div className="ui grid">
          <div className="row centered">
            <h2 className="ui header">
              <div className="content">
                <i>Enforcement App</i>
              </div>
              <a onClick={() => this.props.doHint('enforcementApp')} style={{cursor: "pointer", marginLeft: "10px"}}><i className="info circle icon"></i></a>
            </h2>
          </div>
          <div className="row centered">
            <div className="twelve wide column">
              <div className={`ui input`} style={{ width: "90%" }}>
                <input type="text" className="readOnly" style={{backgroundColor: "#F0F0F0"}} value={this.state.message} onChange={() => { }}></input>
              </div>
              <a onClick={() => this.props.doHint('enforcementAppWorkflow')} style={{ cursor: "pointer", marginLeft: "5px", float: "right" }}><i className="info circle icon"></i></a>
            </div>
          </div>
          <div className="row centered">
            <div className="twelve wide column">
              <div className={`ui primary button`} style={{ width: "90%" }} onClick={() => this.admin()}>
                periodic admin
              </div>
              <a onClick={() => this.props.doHint('enforcementAppAdminButton')} style={{ cursor: "pointer", marginLeft: "5px", float: "right" }}><i className="info circle icon"></i></a>              
            </div>
          </div>
          <div className="row centered">
            <div className="twelve wide column">
              <textarea rows="10" readOnly style={{ width: "100%", fontFamily: "monospace", fontSize: "x-small", backgroundColor: "#F0F0F0" }} value={this.state.log} onChange={() => { }}></textarea>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default OfficerPanel;