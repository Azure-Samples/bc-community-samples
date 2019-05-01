import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { IGameItem } from "./models/IGameItem";
import { GameStore } from "./components/GameStore";

export class App extends React.Component {
  componentDidMount() {
    console.log("mounted app/./...................");
  }
  render() {
    return (
      <div className="App">
        <GameStore />
      </div>
    );
  }
}
