import App from "./lib/App";
import React from "react";
import ReactDOM from "react-dom";

/*** CONFIGURE URLS HERE ***/

// URL to hit the 'ebc-forms-reactjs-post' Azure Logic App
var postUrl = 'https://prod-25.eastus.logic.azure.com:443/workflows/d8abe37d488d471cbe2ece87bcce4086/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=qhE4E23eWol2jDy6OgjpwbB_OO-8ozmyXBQGYQN096s';

// URL to hit the 'ebc-forms-reactjs-get' Azure Logic App
var getUrl = 'https://prod-10.eastus.logic.azure.com:443/workflows/b171adcf5dc64e3f9b36a551757c561c/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=T75EacfKg9zTMH9QgmpnnYXZFdygfRcQqFsyAWcmTEQ';

/*** RENDER APP ***/
ReactDOM.render(<App
  postUrl={postUrl}
  getUrl={getUrl} />,
  document.getElementById('app'));
