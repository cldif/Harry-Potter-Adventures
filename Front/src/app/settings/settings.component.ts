import { Component, OnInit } from "@angular/core";
import { environment } from '../../environments/environment'; 
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: "app-settings-component",

  templateUrl: "settings.component.html",

  styleUrls: ["settings.component.css"]
})

export class SettingsComponent implements OnInit {
  constructor(private router: Router) {}

  url: string;

  port: string;

  ngOnInit() {}

  changeBackUrl(): void {
    var new_url = this.url;
    environment.apiUrl =  this.url; 
  }
}
