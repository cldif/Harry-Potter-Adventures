import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";

import { SettingsService } from "../services/settings.service";

@Component({
  selector: "app-settings-component",
  templateUrl: "settings.component.html",
  styleUrls: ["settings.component.css"]
})
export class SettingsComponent implements OnInit {
  form;

  constructor(
    private formBuilder: FormBuilder,
    private settingsService: SettingsService
  ) {
    this.form = this.formBuilder.group({
      url: this.settingsService.getServerURL(),
      port: this.settingsService.getServerPort(),
      firstScenarioId: this.settingsService.getFirstScenario()
    });
  }

  ngOnInit() {}

  onSubmit(formData) {
    this.settingsService.setServerURL(formData.url);
    this.settingsService.setServerPort(formData.port);
    this.settingsService.setFirstScenario(formData.firstScenarioId);
    console.log("Paramètres enregistrés avec succès !", formData);
  }
}
