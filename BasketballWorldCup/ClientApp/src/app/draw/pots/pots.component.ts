import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

import { TeamState } from "../../store/state/team.state";

@Component({
  selector: "app-pots",
  templateUrl: "./pots.component.html",
  styleUrls: ["./pots.component.css"]
})
export class PotsComponent implements OnInit {
  public title: string;

  constructor(
    private readonly router: Router,
    private store: Store<{ team: TeamState }> ) { }

  ngOnInit(): void {
    this.title = "The Draw: Pots";
  }

  goToNextStep() {

  }

  goToPreviousStep() {
    this.router.navigate(["/simulation/asia"]);
  }
}
