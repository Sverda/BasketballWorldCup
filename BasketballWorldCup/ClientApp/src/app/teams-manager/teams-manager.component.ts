import { Component } from '@angular/core';
import { TeamsService, Team } from "../teams/teams.service";

@Component({
    selector: 'teams-manager',
    templateUrl: './teams-manager.component.html'
})
export class TeamsManagerComponent {
  teamsService: TeamsService;
  teams: Team[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.showTeams();
  }

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }
}
