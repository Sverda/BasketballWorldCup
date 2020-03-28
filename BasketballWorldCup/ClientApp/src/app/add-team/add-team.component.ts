import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ZonesService } from "../services/zones.service";
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { TeamsService, Team } from "../services/teams.service";

@Component({
    templateUrl: './add-team.component.html'
})
export class AddTeamComponent implements OnInit {
  private tiers: number[];
  private zones: string[];
  private imgURL: string;

  public message: string;


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<AddTeamComponent>,
    private teamsService: TeamsService,
    private zonesService: ZonesService) {
  }

  ngOnInit(): void {
    this.tiers = [0, 1, 2, 3];
    this.zonesService.getZones().subscribe(result => { this.zones = result; }, error => console.error(error));
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
    previewReader.readAsDataURL(files[0]);
    previewReader.onload = () => {
      console.log(previewReader.result);
      this.imgURL = previewReader.result as string;
    }
  }

  onSubmit(form: NgForm) {
    form.value.flag = this.imgURL;
    console.log(form.value);
    this.teamsService.addTeam(form.value).subscribe(data => console.log(data));
    this.dialogRef.close();
  }
}
