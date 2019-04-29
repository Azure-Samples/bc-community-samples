import React from "react";
import config from '../config.json';

const home = { left: 30, top: 710, zone: null};
const cityhall = {left: 202, top: 410, zone: 'A'};
const factory = {left: 351, top: 301, zone: 'C'};
const hospital = {left: 97, top: 462, zone: 'B'};
const library = {left: 305, top: 469, zone: 'B'};
const office = {left: 180, top: 298, zone: 'B'};
const school = {left: 201, top: 595, zone: 'C'};

class MapPanel extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      carZone: null,
      carLeft: 30,
      carTop: 710,
      hunterLeft: 364,
      hunterTop: 712,
      enforcementLeft: 215,
      enforcementTop: 700
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({ 
      enforcementLeft: nextProps.enforcementCoordsX ? nextProps.enforcementCoordsX : this.state.enforcementLeft,
      enforcementTop: nextProps.enforcementCoordsY ? nextProps.enforcementCoordsY : this.state.enforcementTop
    });
  }
  checkAndSetAtCar = () => {
    this.props.atCarSetterFn(this.state.carLeft == this.state.hunterLeft && this.state.carTop == this.state.hunterTop);
  }

  moveCar = (destination) => {
    this.setState({ carZone: destination.zone, carLeft: destination.left, carTop: destination.top});
    this.props.carCoordsSetterFn(destination.left, destination.top, destination.zone);
    setTimeout(this.checkAndSetAtCar, 100);
  }

  moveHunter = () => {
    if (this.state.carZone) {
      this.setState({ hunterLeft: this.state.carLeft, hunterTop: this.state.carTop });
    }
    this.props.hunterCoordsSetterFn(this.state.carLeft, this.state.carTop, this.state.carZone);
    setTimeout(this.checkAndSetAtCar, 2100);
  }

  render() {
    return (
      <div>
        <img src="assets/zones.png" onClick={(e) => this.moveCar(e)}>
        </img>
        <img src="assets/car.png" id='car' style={{ 
          position: "absolute", 
          zIndex: "5",
          WebkitTransition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          transition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          top: `${this.state.carTop}px`, 
          left: `${this.state.carLeft}px` }}>
        </img>
        <img src="assets/hunter.png" onClick={() => this.moveHunter()} style={{ 
          position: "absolute", 
          zIndex: "7",
          cursor: "crosshair",
          WebkitTransition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          transition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          top: `${this.state.hunterTop}px`, 
          left: `${this.state.hunterLeft}px` }}>
        </img>
        <img src="assets/policecar.png" style={{ 
          position: "absolute", 
          zIndex: "6",
          WebkitTransition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          transition: `left ${config.animationTimeSeconds}s ease-in-out, top ${config.animationTimeSeconds}s ease-in-out`,
          top: `${this.state.enforcementTop}px`, 
          left: `${this.state.enforcementLeft}px` }}>
        </img>
        <img src="assets/home.png" onClick={() => this.moveCar(home)} style={{ position: "absolute", zIndex: "3", left: `${home.left}px`, top: `${home.top}px`, cursor: "crosshair" }}></img>
        <img src="assets/cityhall.png" onClick={() => this.moveCar(cityhall)} style={{ position: "absolute", zIndex: "3", left: `${cityhall.left}px`, top: `${cityhall.top}px`, cursor: "crosshair"}}></img>
        <img src="assets/factory.png" onClick={() => this.moveCar(factory)} style={{ position: "absolute", zIndex: "3", left: `${factory.left}px`, top: `${factory.top}px`, cursor: "crosshair"}}></img>
        <img src="assets/hospital.png" onClick={() => this.moveCar(hospital)} style={{ position: "absolute", zIndex: "3", left: `${hospital.left}px`, top: `${hospital.top}px`, cursor: "crosshair"}}></img>
        <img src="assets/library.png" onClick={() => this.moveCar(library)} style={{ position: "absolute", zIndex: "3", left: `${library.left}px`, top: `${library.top}px`, cursor: "crosshair"}}></img>
        <img src="assets/office.png" onClick={() => this.moveCar(office)} style={{ position: "absolute", zIndex: "3", left: `${office.left}px`, top: `${office.top}px`, cursor: "crosshair"}}></img>
        <img src="assets/school.png" onClick={() => this.moveCar(school)} style={{ position: "absolute", zIndex: "3", left: `${school.left}px`, top: `${school.top}px`, cursor: "crosshair"}}></img>
      </div>
    );
  }
}

export default MapPanel;