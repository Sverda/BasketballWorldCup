import { Component, OnInit, OnDestroy } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Store } from "@ngrx/store";

import { AddTeamComponent } from "../add-team/add-team.component";
import { Team } from "../model/team.interface";
import { TeamState } from "../store/state/team.state";
import { DeleteTeam } from "../store/actions/team.actions";


@Component({
    selector: "teams-manager",
    templateUrl: "./teams-manager.component.html"
})
export class TeamsManagerComponent implements OnInit, OnDestroy{

  teams: Team[];

  constructor(
    private dialog: MatDialog,
    private store: Store<{ team: TeamState }> ) { }

  ngOnInit(): void {
    this.store.select(state => state.team.teams).subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  ngOnDestroy(): void {
  }

  showNewTeamDialog() {
    this.dialog.open(AddTeamComponent, {});
  }

  onDelete(team: Team) {
    this.store.dispatch(DeleteTeam({ teamId: team.id }));
  }
}
