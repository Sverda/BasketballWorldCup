import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from "rxjs";
import { MatDialog, MatDialogRef } from '@angular/material';
import { TeamsService, Team } from "../services/teams.service";
import { AddTeamComponent } from "../add-team/add-team.component";

@Component({
    selector: 'teams-manager',
    templateUrl: './teams-manager.component.html'
})
export class TeamsManagerComponent implements OnInit, OnDestroy{

  teamsService: TeamsService;
  teamAddedSubs: Subscription;
  teams: Team[];

  constructor(private dialog:  MatDialog, teamsService: TeamsService) {
    this.teamsService = teamsService;
  }

  ngOnInit(): void {
    this.showTeams();
    this.teamAddedSubs = this.teamsService.addedUserSubject.subscribe(data => { this.teams.push(data) });
  }

  ngOnDestroy(): void {
    this.teamAddedSubs.unsubscribe();
  }

  showNewTeamDialog() {
    this.dialog.open(AddTeamComponent, {});
  }

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  onDelete(team: Team) {
    this.teams = this.teams.filter(t => t.id !== team.id);

    this.teamsService.deleteTeam(team).subscribe(data => console.log(data));
  }
}
