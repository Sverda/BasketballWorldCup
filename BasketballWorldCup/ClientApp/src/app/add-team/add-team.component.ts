import { Component, OnInit } from '@angular/core';
import { TeamsService, Team } from "../services/teams.service";
import { ZonesService } from "../services/zones.service";

@Component({
    selector: 'add-team',
    templateUrl: './add-team.component.html'
})
export class AddTeamComponent implements OnInit {

  private readonly zonesService: ZonesService;
  private readonly teamsService: TeamsService;
  private newTeam: Team;
  private tiers: number[];
  private zones: string[];
  private imgURL: string;

  public imagePath: File[];
  public message: string;


  constructor(teamsService: TeamsService, zonesService: ZonesService) {
    this.teamsService = teamsService;
    this.zonesService = zonesService;
  }

  ngOnInit(): void {
    this.tiers = [0, 1, 2, 3];
    this.zonesService.getZones().subscribe(result => { this.zones = result; }, error => console.error(error));
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "", flag: null };
  }

  preview(files: File[]) {
    if (files.length === 0 || files.length > 1)
      return;

    const mimeType = files[0].type;
    if (mimeType.match(/image\/*/) === null) {
      this.message = "Only images are supported.";
      return;
    }

    const previewReader = new FileReader();
    this.imagePath = files;
    previewReader.readAsDataURL(files[0]);
    previewReader.onload = () => {
      console.log(previewReader.result);
      this.newTeam.flag = previewReader.result as string;
    }
  }

  addTeam() {
    this.teamsService.addTeam(this.newTeam).subscribe(data => console.log(data));
    this.newTeam = { id: 0, name: "", tier: 1, qualificationZone: "", flag: null };
  }
}
