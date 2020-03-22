import { Component, OnInit } from '@angular/core';
import { TeamsService, Team } from "../services/teams.service";
import { ZonesService } from "../services/zones.service";

@Component({
    selector: 'add-team',
    templateUrl: './add-team.component.html'
})
export class AddTeamComponent implements OnInit {

  private readonly zonesService: ZonesService;
  private readonly teamsService: TeamsService;
  private newTeam: Team;
  private tiers: number[];
  private zones: string[];

  constructor(teamsService: TeamsService, zonesService: ZonesService) {
    this.teamsService = teamsService;
    this.zonesService = zonesService;
  }

  ngOnInit(): void {
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "" };
    this.tiers = [0, 1, 2, 3];
    this.zonesService.getZones().subscribe(result => { this.zones = result; }, error => console.error(error));
  }

  addTeam() {
    this.teamsService.addTeam(this.newTeam).subscribe(data => console.log(data));
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "" };
  }
}
