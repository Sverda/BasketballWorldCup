import { Component } from '@angular/core';
import { ITeam, TeamsService } from "./teams.service";

@Component
({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
})

export class TeamsComponent
{
  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.showTeams();
  }

  teams: ITeam[];
  teamsService: TeamsService;

  showTeams()
  {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }
}
