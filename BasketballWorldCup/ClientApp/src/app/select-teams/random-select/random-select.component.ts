import { Component, OnInit, Input } from "@angular/core";
import { Store } from "@ngrx/store";
import { map } from "rxjs/operators";

import { TeamState } from "../../store/state/team.state";
import { Team } from "../../model/team.interface";
import { SelectOrUnselectTeam } from "../../store/actions/team.actions";

@Component({
  selector: "app-random-select",
  templateUrl: "./random-select.component.html",
  styleUrls: ["./random-select.component.css"]
})
export class RandomSelectComponent implements OnInit {
  public teams: Team[];

  @Input() zoneName: string;

  constructor(
    private store: Store<{ team: TeamState }>
  ) { }

  ngOnInit(): void {
    this.store.select(state => state.team.teams)
      .pipe(map((data: Team[]) => data.filter(t => t.qualificationZone === this.zoneName)))
      .subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  public onClick() {
    const firstTier = this.teams.filter((team: Team) => team.tier === 0);
    const randomFirstTier = this.randomTeams(firstTier, 2);
    this.selectTeams(randomFirstTier);

    const otherTiers = this.teams.filter((team: Team) => team.tier !== 0);
    const randomOtherTiers = this.randomTeams(otherTiers, 6);
    this.selectTeams(randomOtherTiers);
  }

  randomTeams(teams: Team[], amount: number): Team[] {
    const randomTeams: Team[] = [];
    const amountArray = new Array(amount); 
    for (let i of amountArray) {
      const team = teams[Math.floor(Math.random() * teams.length)];
      randomTeams.push(team);
    }

    return randomTeams;
  }

  selectTeams(firstTier: Team[]) {
    for (let team of firstTier) {
      this.selectTeam(team);
    }
  }

  selectTeam(team: Team) {
    let updatedTeam = { ...team };
    if (updatedTeam.isSelected) {
      updatedTeam.isSelected = false;
    } else {
      updatedTeam.isSelected = true;
    }

    this.store.dispatch(SelectOrUnselectTeam({ team: updatedTeam }));
  }
}
