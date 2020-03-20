import { Component } from '@angular/core';
import { TeamsService, Team } from "./teams.service";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
})
export class TeamsComponent
{
  teamsService: TeamsService;
  teamsByTier: Team[][]
  selectedTeams: Team[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.teamsByTier = [];
    this.showTeamsByTier(0);
    this.showTeamsByTier(1);
    this.showTeamsByTier(2);
    this.showTeamsByTier(3);
    this.selectedTeams = [];
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
