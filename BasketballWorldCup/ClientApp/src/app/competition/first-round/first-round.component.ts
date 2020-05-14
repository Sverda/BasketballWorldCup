import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { AppState } from "../../store/state/app.state";

@Component({
  selector: "app-first-round",
  templateUrl: "./first-round.component.html",
  styleUrls: ["./first-round.component.css"]
})
export class FirstRoundComponent implements OnInit {
  public title: string;

  constructor(
    private readonly router: Router,
    private readonly store: Store<AppState> ) { }

  ngOnInit(): void {
    this.title = "The First Round: Result";
  }

  goToNextStep() {

  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/groups"]);
  }
}
