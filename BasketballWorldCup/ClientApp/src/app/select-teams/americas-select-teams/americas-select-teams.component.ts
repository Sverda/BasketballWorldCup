import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-americas-select-teams",
  templateUrl: "./americas-select-teams.component.html",
  styleUrls: ["./americas-select-teams.component.css"]
})
export class AmericasSelectTeamsComponent implements OnInit {
  public zoneId = 2;
  public zoneName = "Americas";
  public previousFormPath = "/simulation/europe";
  public nextFormPath = "/simulation/asia";

  constructor() { }

  ngOnInit(): void {
  }

}
