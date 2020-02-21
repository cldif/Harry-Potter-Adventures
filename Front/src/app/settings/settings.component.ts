import { Component, OnInit } from "@angular/core";

import { Router } from "@angular/router";

@Component({
  selector: "app-settings-component",

  templateUrl: "settings.component.html",

  styleUrls: ["settings.component.css"]
})
export class SettingsComponent implements OnInit {
  constructor(private router: Router) {}

  username: string;

  password: string;

  ngOnInit() {}

  login(): void {
    if (this.username == "admin" && this.password == "admin") {
      this.router.navigate(["user"]);
    } else {
      alert("Invalid credentials");
    }
  }
}
