import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SettingsService {
  settings = {
    serverURL: "https://harrypotterapiisima.azurewebsites.net",
    serverPort: 443,
    firstScenarioId: 1
  };

  constructor() {}

  setServerURL(url) {
    this.settings.serverURL = url;
  }

  setServerPort(port) {
    this.settings.serverPort = port;
  }

  setFirstScenario(id) {
    this.settings.firstScenarioId = id;
  }

  getServerURL() {
    return this.settings.serverURL;
  }

  getServerPort() {
    return this.settings.serverPort;
  }

  getFirstScenario() {
    return this.settings.firstScenarioId;
  }
}
