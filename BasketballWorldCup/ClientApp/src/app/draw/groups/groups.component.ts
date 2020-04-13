import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { AppState } from "../../store/state/app.state";
import { Draw } from "../../model/draw.interface";
import { AddDraw } from "../../store/actions/draw.actions";

@Component({
  selector: "app-groups",
  templateUrl: "./groups.component.html",
  styleUrls: ["./groups.component.css"]
})
export class GroupsComponent implements OnInit {
  public title: string;
  public draw: Draw;

  constructor(
    private readonly router: Router,
    private readonly store: Store<AppState> ) { }

  ngOnInit(): void {
    this.title = "The Draw: Groups";

    this.store
      .select(state => state.draw)
      .subscribe(result => this.draw = result.draw, error => console.error(error));

    if (this.draw === null) {
      this.store.dispatch(AddDraw());
    }
    else if (this.draw.groups === null) {
      this.store.dispatch(UpdateDrawWithGroups());
    }
  }

  goToNextStep() {

  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/pots"]);
  }
}
