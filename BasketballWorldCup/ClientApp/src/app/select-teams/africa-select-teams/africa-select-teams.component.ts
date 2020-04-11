import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-africa-select-teams",
  templateUrl: "./africa-select-teams.component.html",
  styleUrls: ["./africa-select-teams.component.css"]
})
export class AfricaSelectTeamsComponent implements OnInit {
  public zoneId = 0;
  public zoneName = "Africa";
  public nextFormPath = "/simulation/europe";

  ngOnInit() {

  }
}
