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
    this.tiers = [0, 1, 2, 3];
    this.zonesService.getZones().subscribe(result => { this.zones = result; }, error => console.error(error));
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "", flag: null };
  }

  onFileChanged(event) {
    console.log(event.target.files[0]);
    this.newTeam.flag = event.target.files[0];
  }

  addTeam() {
    this.teamsService.addTeam(this.newTeam).subscribe(data => console.log(data));
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "", flag: null };
  }
}
