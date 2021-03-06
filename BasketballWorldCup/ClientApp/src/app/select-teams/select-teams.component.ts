import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup } from "@angular/forms";
import { map } from "rxjs/operators";
import { Store } from "@ngrx/store";

import { Team } from "../model/team.interface";
import { TeamState } from "../store/state/team.state";
import { SelectOrUnselectTeam } from "../store/actions/team.actions";

@Component({
  selector: "app-select-teams",
  templateUrl: "./select-teams.component.html",
  styleUrls: ["./select-teams.component.css"]
})
export class SelectTeamsComponent implements OnInit {
  public title: string;
  private submitted = false;
  public teams: Team[];
  public teamsForm: FormGroup;

  @Input() zoneId: number;
  @Input() zoneName: string;
  @Input() previousFormPath: string;
  @Input() nextFormPath: string;

  constructor(
    private readonly router: Router,
    private readonly fb: FormBuilder,
    private store: Store<{ team: TeamState }> 
  ) {}

  ngOnInit() {
    this.title = "Kwalifikacje: " + this.zoneName;
    this.teams = [];

    this.teamsForm = this.fb.group({
      teamsControl: this.fb.array(
        this.teams.map((team: Team) => this.fb.control(team.name)),
        [this.amountValidator.bind(this), this.firstTierValidator.bind(this)]
      )
    });

    this.store.select(state => state.team.teams)
      .pipe(map((data: Team[]) => data.filter(t => t.qualificationZone === this.zoneName)))
      .subscribe(result => { this.teams = result; this.teamsForm.patchValue({ teamsControl: result}); }, error => console.error(error));
  }

  amountValidator(): { [s: string]: boolean } {
    if (this.teams === undefined) {
      return null;
    }

    const selectedTeams = this.teams.filter(t => t.isSelected).length;
    if (selectedTeams !== 8) {
      return { incorrectAmount: true };
    }

    return null;
  }

  firstTierValidator(): { [s: string]: boolean } {
    if (this.teams === undefined) {
      return null;
    }

    const selectedTeams = this.teams.filter(t => t.isSelected && t.tier === 0).length;
    if (selectedTeams < 2) {
      return { incorrectFirstTier: true };
    }

    return null;
  }

  hasAmount(): boolean {
    return !this.teamsForm.get("teamsControl").hasError("incorrectAmount");
  }

  hasTier(): boolean {
    return !this.teamsForm.get("teamsControl").hasError("incorrectFirstTier");
  }

  selectTeam(team: Team) {
    const updatedTeam = { ...team };
    if (updatedTeam.isSelected) {
      updatedTeam.isSelected = false;
    } else {
      updatedTeam.isSelected = true;
    }

    this.store.dispatch(SelectOrUnselectTeam({ team: updatedTeam }));
  }

  goToNextStep() {
    this.submitted = true;

    if (!this.teamsForm.valid) {
      return;
    }

    if (this.nextFormPath === undefined) {
      return;
    }

    this.router.navigate([this.nextFormPath]);
  }

  goToPreviousStep() {
    if (this.previousFormPath === undefined) {
      return;
    }

    this.router.navigate([this.previousFormPath]);
  }
}
