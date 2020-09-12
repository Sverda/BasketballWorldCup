import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { AppState } from "../../store/state/app.state";
import { GroupResult } from "../../model/group-result.interface";
import { GetFinalRound } from "../../store/actions/rounds.actions";

@Component({
  selector: "app-final-round",
  templateUrl: "./final-round.component.html",
  styleUrls: ["./final-round.component.css"]
})
export class FinalRoundComponent implements OnInit {
  public title: string;
  public groupsResult: GroupResult[];

  constructor(
    private readonly router: Router,
    private readonly store: Store<AppState> ) { }

  ngOnInit(): void {
    this.title = "Faza Pucharowa";

    this.store
      .select(state => state.rounds.finalRound)
      .subscribe(result => this.groupsResult = result, error => console.error(error));
    
    if (this.groupsResult === null) {
      this.store.dispatch(GetFinalRound());
    }
  }

  goToNextStep() {

  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/final-round"]);
  }
}
