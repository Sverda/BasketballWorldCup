import { Component } from '@angular/core';
import { TeamsService, Team } from "./teams.service";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
})

export class TeamsComponent
{
  teams: Team[];
  teamsByTier: Team[][]
  teamsService: TeamsService;
  selectedTeams: Team[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.showTeams();
    this.teamsByTier = [];
    this.showTeamsByTier(0);
    this.showTeamsByTier(1);
    this.showTeamsByTier(2);
    this.showTeamsByTier(3);
    this.selectedTeams = [];
  }

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  showTeamsByTier(tier: number) {
    this.teamsService.getTeamsByTier(tier).subscribe(result => { this.teamsByTier[tier] = result; }, error => console.error(error));
  }

  onTeamSelect(team: Team) {
    if (this.selectedTeams.filter(t => t.id === team.id).length > 0) {
      this.selectedTeams = this.selectedTeams.filter(t => t.id !== team.id);
    }
    else {
      this.selectedTeams.push(team);
    }
  }

  isActive(team: Team): boolean {
    return this.selectedTeams.filter(t => t.id === team.id).length > 0;
  }
}
