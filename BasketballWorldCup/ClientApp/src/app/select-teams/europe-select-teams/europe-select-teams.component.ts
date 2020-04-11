import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-europe-select-teams",
  templateUrl: "./europe-select-teams.component.html",
  styleUrls: ["./europe-select-teams.component.css"]
})
export class EuropeSelectTeamsComponent implements OnInit {
  public zoneId = 1;
  public zoneName = "Europe";
  public previousFormPath = "/simulation/africa";
  public nextFormPath = "/simulation/americas";

  constructor() { }

  ngOnInit(): void {
  }

}
