import { Component } from '@angular/core';
import { TeamsService, Team } from "../teams/teams.service";

@Component({
    selector: 'teams-manager',
    templateUrl: './teams-manager.component.html'
})
export class TeamsManagerComponent {
  teamsService: TeamsService;
  teams: Team[];
  newTeam: Team;
  tiers: number[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.showTeams();
    this.newTeam = { id: 0, name: "", tier: 1 };
    this.tiers = [0, 1, 2, 3];
  }

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  addTeam() {
    this.teamsService.addTeam(this.newTeam);
    this.teams.push(this.newTeam);
    this.newTeam = { id: 0, name: "", tier: 1 };
  }
}
