import { Component } from '@angular/core';
import { TeamsService, Team } from "./teams.service";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
})

export class TeamsComponent
{
  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.showTeams();
    this.teamsByTier = [];
    this.showTeamsByTier(1);
    this.showTeamsByTier(2);
    this.showTeamsByTier(3);
    this.showTeamsByTier(4);
  }

  teams: Team[];
  teamsByTier: Team[][]
  teamsService: TeamsService;

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  showTeamsByTier(tier: number) {
    this.teamsService.getTeamsByTier(tier).subscribe(result => { this.teamsByTier[tier] = result; }, error => console.error(error));
  }
}
