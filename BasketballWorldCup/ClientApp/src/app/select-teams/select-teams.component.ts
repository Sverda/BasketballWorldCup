import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { TeamsService, Team } from "../services/teams.service";
import { ZonesService } from "../services/zones.service";
import { FormBuilder, FormGroup } from "@angular/forms";
import { map } from "rxjs/operators";

@Component({
  selector: "app-select-teams",
  templateUrl: "./select-teams.component.html",
  styleUrls: ["./select-teams.component.css"]
})
export class SelectTeamsComponent implements OnInit {
  public title: string;
  private submitted = false;
  public teams: SelectionTeam[];
  private selectTeamsGroup: FormGroup;
  @Input() zoneId: number;

  constructor(
    private readonly router: Router,
    private readonly route: ActivatedRoute,
    private readonly teamsService: TeamsService,
    private readonly zonesService: ZonesService,
    private readonly fb: FormBuilder,
  ) {}

  ngOnInit() {
    this.title = "Zone: " + this.zoneId;
    this.selectTeamsGroup = this.fb.group({});

    this.teamsService
      .getTeamsByZone(this.zoneId)
      .pipe(map((data: Team[]) => data.map(t => new SelectionTeam(t))))
      .subscribe(result => { this.teams = result; }, error => console.error(error));
  }

  selectTeam(team: SelectionTeam) {
    if (team.isSelected()) {
      team.unselect();
    } else {
      team.select();
    }
  }

  goToNextStep() {
    this.submitted = true;
  }
}

class SelectionTeam {
  private selected: boolean;

  constructor(public readonly data: Team) {
    this.unselect();
  }

  isSelected(): boolean {
    return this.selected;
  }

  select() {
    this.selected = true;
  }

  unselect() {
    this.selected = false;
  }
}
