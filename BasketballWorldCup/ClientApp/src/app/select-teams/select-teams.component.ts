import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup } from "@angular/forms";
import { map, filter } from "rxjs/operators";
import { Store } from "@ngrx/store";

import { ZonesService } from "../services/zones.service";
import { TeamsService } from "../services/teams.service";
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
  public selectTeamsGroup: FormGroup;

  @Input() zoneId: number;
  @Input() zoneName: string;

  constructor(
    private readonly router: Router,
    private readonly route: ActivatedRoute,
    private readonly teamsService: TeamsService,
    private readonly zonesService: ZonesService,
    private readonly fb: FormBuilder,
    private store: Store<{ team: TeamState }> 
  ) {}

  ngOnInit() {
    this.title = "Zone: " + this.zoneId;
    this.selectTeamsGroup = this.fb.group({});

    this.store.select(state => state.team.teams)
      .pipe(map((data: Team[]) => data.filter(t => t.qualificationZone === this.zoneName)))
      .subscribe(result => { this.teams = result; }, error => console.error(error));
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

  goToNextStep() {
    this.submitted = true;
  }
}
