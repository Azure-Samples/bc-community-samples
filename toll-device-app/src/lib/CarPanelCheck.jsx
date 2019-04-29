import config from "../config.json";
import {makePretendChallengeAndSign} from "./utils";

import React from "react";

class CarPanelCheck extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      timeRemaining: {
        zoneA: 'none',
        zoneB: 'none',
        zoneC: 'none'
      }
    };

    this.props.setCheckTimeRemainingFn(this.checkTimeRemaining);
  }

  // check smart-contract for remaining time in each zone for the car
  //
  // @param {boolean} workSilently - if shouldn't update UX with loaders and messaging
  checkTimeRemaining = (workSilently) => {
    if (!workSilently) {
      this.props.setLoading(true);
      this.props.doHint('checkTimeAzure');
    }
    var signature = makePretendChallengeAndSign(this.props.privateKey);
    fetch(config.check__AzureURL, { 
      method: "POST", 
      headers: { "Content-Type": "application/json; charset=utf-8" }, 
      body: JSON.stringify({ 
        formId: config.admin__FormId,
        challengeHash: signature.messageHash,
        r: signature.r,
        s: signature.s,
        v: signature.v,
        carAddress: this.props.carAddress,
        contractAddress: config.ethereumContractAddress
      }) 
    })
    .then(response => {
      if (response.status == 200) {
        return response.json()
      } else {
        return response.text().then(error => {throw error});
      }
    })
    .then(response => {
      if (!workSilently) {
        console.log(`checkTimeRemaining :: ${JSON.stringify(response, null, 2)}`);
      }
      let dateOptions = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
      let now = (new Date()).getTime();
      let zoneATimeout = response.zoneATimeout * 1000; // into millis
      let zoneBTimeout = response.zoneBTimeout * 1000; // into millis
      let zoneCTimeout = response.zoneCTimeout * 1000; // into millis
      this.setState({
        timeRemaining: {
          zoneA: zoneATimeout > now ? new Date(zoneATimeout).toLocaleDateString("en-US", dateOptions) : 'Needs Top-Up',
          zoneB: zoneBTimeout > now ? new Date(zoneBTimeout).toLocaleDateString("en-US", dateOptions) : 'Needs Top-Up',
          zoneC: zoneCTimeout > now ? new Date(zoneCTimeout).toLocaleDateString("en-US", dateOptions) : 'Needs Top-Up'
        }});
      if (!workSilently) {
        this.props.doHint(null);
        this.props.setLoading(false)
      }
    })
    .catch(error => { 
      if (!workSilently) {
        this.props.setLoading(false);
      }
      this.props.setError(error)
    });
    return false;
  }

  componentDidMount() {
    setTimeout(() => this.checkTimeRemaining(true), config.animationTimeSeconds * 1000);   // # seconds after mounting hit up Azure
    setInterval(() => this.checkTimeRemaining(true), 30000); // every 30 seconds silently hit up Azure
  }

  render() {
    return (
      <div className="ui grid">
        <div className="row centered">
          <div className="twelve wide column">
            <span className="ui heading"style={{fontSize: "larger", fontStyle: "italic", width: "90%"}}>time remaining</span>
            <a onClick={() => this.props.doHint('carAppTimeRemaining')} style={{ cursor: "pointer", marginLeft: "5px", float: "right" }}><i className="info circle icon"></i></a>
          </div>                
        </div>
        <div className="row centered twelve wide">
          <div className="twelve wide column">
            <div className="ui labeled input fluid">
              <div className="ui label" style={{ background: "#ffb3b3"}}>
                Zone A
              </div>
              <input type='text' value={this.state.timeRemaining.zoneA} disabled></input>
            </div>
          </div>
        </div>
        <div className="row centered twelve wide">
          <div className="twelve wide column">
            <div className="ui labeled input fluid">
              <div className="ui label" style={{ background: "#e6e600" }}>
                Zone B
              </div>
              <input type='text' value={this.state.timeRemaining.zoneB} disabled></input>
            </div>
          </div>            
        </div>
        <div className="row centered twelve wide">
          <div className="twelve wide column">
            <div className="ui labeled input fluid">
              <div className="ui label" style={{ background: "#ffe4b3" }}>
                Zone C
              </div>
              <input type='text' value={this.state.timeRemaining.zoneC} disabled></input>
            </div>
          </div>            
        </div>          
      </div>
    );
  }
}

export default CarPanelCheck;