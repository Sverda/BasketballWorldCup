import { Component, OnInit, OnDestroy } from '@angular/core';
import { TeamsService, Team } from "../teams/teams.service";
import { Subscription } from "rxjs";

@Component({
    selector: 'teams-manager',
    templateUrl: './teams-manager.component.html'
})
export class TeamsManagerComponent implements OnInit, OnDestroy{

  teamsService: TeamsService;
  teamAddedSubs: Subscription;
  teams: Team[];

  constructor(teamsService: TeamsService) {
    this.teamsService = teamsService;
  }

  ngOnInit(): void {
    this.showTeams();
    this.teamAddedSubs = this.teamsService.addedUserSubject.subscribe(data => { this.teams.push(data) });
  }

  ngOnDestroy(): void {
    this.teamAddedSubs.unsubscribe();
  }

  showTeams() {
    this.teamsService.getTeams().subscribe(result => { this.teams = result; }, error => console.error(error));
  }
}
