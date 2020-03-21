import { Component } from '@angular/core';
import { Team, TeamsService } from "../teams/teams.service";

@Component({
    selector: 'add-team',
    templateUrl: './add-team.component.html'
})
export class AddTeamComponent {
  teamsService: TeamsService;
  newTeam: Team;
  tiers: number[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
    this.newTeam = { id: 0, name: "", tier: 1 };
    this.tiers = [0, 1, 2, 3];
  }

  addTeam() {
    this.teamsService.addTeam(this.newTeam).subscribe(data => console.log(data));
    this.newTeam = { id: 0, name: "", tier: 1 };
  }
}
