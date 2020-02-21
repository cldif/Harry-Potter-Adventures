import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { environment } from "../../environments/environment";
import { RestErrorComponent } from "./rest-error/rest-error.component";

import { MatDialog } from "@angular/material/dialog";

@Component({
  selector: "app-game",
  templateUrl: "game.component.html",
  styleUrls: ["game.component.css"]
})
export class GameComponent implements OnInit {
  scenarioHistory = [];
  lastScenario;

  constructor(private http: HttpClient, public dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(RestErrorComponent, {
      width: "400px"
    });
  }

  fetchScenario(id: number) {
    return this.http
      .get(environment.apiUrl + "/api/Scenario/" + id)
      .toPromise();
  }

  getLastScenario() {
    return this.scenarioHistory[this.scenarioHistory.length - 1];
  }

  async updateComponent(scenarioId: number) {
    try {
      this.lastScenario = await this.fetchScenario(scenarioId);
      this.scenarioHistory.push(this.lastScenario);
    } catch (error) {
      console.error(error);
      this.openDialog();
    }
  }

  ngOnInit() {
    this.updateComponent(environment.firstScenarioId);
  }
}
