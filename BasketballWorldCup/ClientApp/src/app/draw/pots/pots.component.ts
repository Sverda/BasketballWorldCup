import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { Draw } from "../../model/draw.interface";
import { AppState } from "../../store/state/app.state";
import { AddDraw } from "../../store/actions/draw.actions";

@Component({
  selector: "app-pots",
  templateUrl: "./pots.component.html",
  styleUrls: ["./pots.component.css"]
})
export class PotsComponent implements OnInit {
  public title: string;
  public draw: Draw;

  constructor(
    private readonly router: Router,
    private readonly store: Store<AppState> ) { }

  ngOnInit(): void {
    this.title = "Losowanie: Koszyki";

    this.store
      .select(state => state.draw)
      .subscribe(result => this.draw = result.draw, error => console.error(error));

    if (this.draw.pots === null) {
      this.store.dispatch(AddDraw());
    }
  }

  goToNextStep() {
    this.router.navigate(["/simulation/groups"]);
  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/asia"]);
  }
}
