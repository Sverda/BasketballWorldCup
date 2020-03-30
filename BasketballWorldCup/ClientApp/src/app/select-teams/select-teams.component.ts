import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder, Validators } from "@angular/forms";
import { TeamsService } from "../services/teams.service";
import { ZonesService } from "../services/zones.service";

@Component({
  selector: "app-select-teams",
  templateUrl: "./select-teams.component.html",
  styleUrls: ["./select-teams.component.css"]
})
export class SelectTeamsComponent implements OnInit {
  private title: string;
  private submitted = false;
  selectTeamsForm = this.fb.group(
    {
      firstName: [null, [Validators.required]]
    },
    {
      updateOn: "blur"
    }
  );

  @Input() zoneId: string;

  constructor(
    private readonly router: Router,
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    private readonly teamsService: TeamsService,
    private readonly zonesService: ZonesService
  ) { }

  ngOnInit() {
    console.log("Select teams: " + this.zoneId);
    this.title = "Zone: " + this.zoneId;
  }

  goToNextStep() {
    this.submitted = true;
  }
}
