import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";

@Component({
  selector: "app-game",
  templateUrl: "game.component.html",
  styleUrls: ["game.component.css"]
})
export class GameComponent implements OnInit {
  readonly firstScenarioId = 1;

  scenarioHistory = [];

  constructor(private http: HttpClient) {}

  fetchScenario(id) {
    return this.http
      .get(environment.apiUrl + "/api/Scenario/" + id)
      .subscribe(result => {
        this.scenarioHistory.push(result);
      });
  }

  getChoicesArray() {
    let array = [];
    if (this.scenarioHistory[this.scenarioHistory.length - 1]) {
      if (this.scenarioHistory[this.scenarioHistory.length - 1].Choice1) {
        array.push({
          text: this.scenarioHistory[this.scenarioHistory.length - 1].Choice1
            .Text,
          nextId: this.scenarioHistory[this.scenarioHistory.length - 1].Choice1
            .ScenarioId
        });
      }
      if (this.scenarioHistory[this.scenarioHistory.length - 1].Choice2) {
        array.push({
          text: this.scenarioHistory[this.scenarioHistory.length - 1].Choice2
            .Text,
          nextId: this.scenarioHistory[this.scenarioHistory.length - 1].Choice2
            .ScenarioId
        });
      }
      if (this.scenarioHistory[this.scenarioHistory.length - 1].Choice3) {
        array.push({
          text: this.scenarioHistory[this.scenarioHistory.length - 1].Choice3
            .Text,
          nextId: this.scenarioHistory[this.scenarioHistory.length - 1].Choice3
            .ScenarioId
        });
      }
      if (this.scenarioHistory[this.scenarioHistory.length - 1].Choice4) {
        array.push({
          text: this.scenarioHistory[this.scenarioHistory.length - 1].Choice4
            .Text,
          nextId: this.scenarioHistory[this.scenarioHistory.length - 1].Choice4
            .ScenarioId
        });
      }
    }
    return array;
  }

  ngOnInit() {
    this.fetchScenario(this.firstScenarioId);
  }
}
