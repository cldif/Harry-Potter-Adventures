import { Component } from "@angular/core";

import { MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: "app-rest-error",
  templateUrl: "rest-error.html",
  styleUrls: ["rest-error.css"]
})
export class RestErrorComponent {
  constructor(public dialogRef: MatDialogRef<RestErrorComponent>) {}
}
