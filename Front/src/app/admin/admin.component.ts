import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { FormBuilder } from "@angular/forms";

import { SettingsService } from "../services/settings.service";

import { MatDialog } from "@angular/material/dialog";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css"]
})
export class AdminComponent implements OnInit {
  contentType = "scenarioModification";

  choicesArray;
  scenariosArray;

  scenarioModifForm;
  scenarioDelForm;
  choiceAddForm;
  choiceDelForm;

  constructor(
    private http: HttpClient,
    public dialog: MatDialog,
    private formBuilder: FormBuilder,
    private settingsService: SettingsService
  ) {
    this.scenarioModifForm = this.formBuilder.group({
      Label: "",
      Text: "",
      GameOver: 0
    });

    this.scenarioDelForm = this.formBuilder.group({
      Id: ""
    });

    this.choiceAddForm = this.formBuilder.group({
      CurrentScenarioId: "",
      NextScenarioId: "",
      Text: ""
    });

    this.choiceDelForm = this.formBuilder.group({
      Id: ""
    });
  }

  ngOnInit() {
    this.refreshScenariosArray();
    this.refreshChoicesArray();
  }

  updateComponent(value) {
    this.contentType = value;
    this.refreshScenariosArray();
    this.refreshChoicesArray();
  }

  async refreshScenariosArray() {
    try {
      this.scenariosArray = await this.http
        .get(this.settingsService.getFullURL() + "/api/Scenario/")
        .toPromise();
    } catch (error) {
      console.error(error);
    }
  }

  async refreshChoicesArray() {
    try {
      this.choicesArray = await this.http
        .get(this.settingsService.getFullURL() + "/api/Choice/")
        .toPromise();
    } catch (error) {
      console.error(error);
    }
  }

  prepareScenarioModification(data) {
    const headers = new HttpHeaders({
      "Content-Type": "application/json"
    });
    const options = { headers: headers, method: "POST" };

    return this.http
      .post(this.settingsService.getFullURL() + "/api/Scenario/", data, options)
      .toPromise();
  }

  async sendScenarioModification(data) {
    try {
      const result = await this.prepareScenarioModification(data);
      console.log(result);
      console.log("Modifications prises en compte !", data);
    } catch (error) {
      console.error(error);
    }
  }

  submitScenarioModification(formData) {
    this.sendScenarioModification(formData);
  }

  prepareScenarioDeletion(data) {
    const headers = new HttpHeaders({
      "Content-Type": "application/json"
    });
    const options = { headers: headers, method: "DELETE" };

    return this.http
      .delete(
        this.settingsService.getFullURL() + "/api/Scenario/" + data.Id,
        options
      )
      .toPromise();
  }

  async sendScenarioDeletion(data) {
    try {
      const result = await this.prepareScenarioDeletion(data);
      console.log(result);
      console.log("Scénario supprimé avec succès !", data);
    } catch (error) {
      console.error(error);
    }
  }

  submitScenarioDeletion(formData) {
    this.sendScenarioDeletion(formData);
  }

  prepareChoiceAddition(data) {
    const headers = new HttpHeaders({
      "Content-Type": "application/json"
    });
    const options = { headers: headers, method: "POST" };

    return this.http
      .post(this.settingsService.getFullURL() + "/api/Choice", data, options)
      .toPromise();
  }

  async sendChoiceAddition(data) {
    try {
      const result = await this.prepareChoiceAddition(data);
      console.log(result);
      console.log("Choix ajouté avec succès !", data);
    } catch (error) {
      console.error(error);
    }
  }

  submitChoiceAddition(formData) {
    this.sendChoiceAddition(formData);
  }

  prepareChoiceDeletion(data) {
    const headers = new HttpHeaders({
      "Content-Type": "application/json"
    });
    const options = { headers: headers, method: "DELETE" };

    return this.http
      .delete(
        this.settingsService.getFullURL() + "/api/Choice/" + data.Id,
        options
      )
      .toPromise();
  }

  async sendChoiceDeletion(data) {
    try {
      const result = await this.prepareChoiceDeletion(data);
      console.log(result);
      console.log("Choix supprimé avec succès !", data);
    } catch (error) {
      console.error(error);
    }
  }

  submitChoiceDeletion(formData) {
    this.sendChoiceDeletion(formData);
  }
}
