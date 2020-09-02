import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { AppState } from "../../store/state/app.state";
import { GroupResult } from "../../model/group-result.interface";
import { GetSecondRound } from "../../store/actions/rounds.actions";

@Component({
  selector: "app-second-round",
  templateUrl: "./second-round.component.html",
  styleUrls: ["./second-round.component.css"]
})
export class SecondRoundComponent implements OnInit {
  public title: string;
  public groupsResult: GroupResult[];

  constructor(
    private readonly router: Router,
    private readonly store: Store<AppState> ) { }

  ngOnInit(): void {
    this.title = "Druga Faza Grupowa";

    this.store
      .select(state => state.rounds.secondRound)
      .subscribe(result => this.groupsResult = result, error => console.error(error));
    
    if (this.groupsResult === null) {
      this.store.dispatch(GetSecondRound());
    }
  }

  goToNextStep() {

  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/first-round"]);
  }
}
