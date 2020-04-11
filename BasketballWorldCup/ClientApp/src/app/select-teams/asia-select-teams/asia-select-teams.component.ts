import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-asia-select-teams",
  templateUrl: "./asia-select-teams.component.html",
  styleUrls: ["./asia-select-teams.component.css"]
})
export class AsiaSelectTeamsComponent implements OnInit {
  public zoneId = 3;
  public zoneName = "Asia & Oceania";
  public previousFormPath = "/simulation/americas";

  constructor() { }

  ngOnInit(): void {
  }

}
