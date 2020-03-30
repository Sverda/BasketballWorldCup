import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ZonesService } from "../services/zones.service";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TeamsService } from "../services/teams.service";

@Component({
    templateUrl: './add-team.component.html'
})
export class AddTeamComponent implements OnInit {
  @ViewChild("f", { static: false }) addTeamForm: NgForm;
  public tiers: number[];
  public zones: string[];
  private flagData: string;

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
      this.flagData = previewReader.result as string;
    }
  }

  onSubmit() {
    this.addTeamForm.value.flag = this.flagData;
    console.log(this.addTeamForm.value);
    this.teamsService.addTeam(this.addTeamForm.value).subscribe(data => console.log(data));
    this.dialogRef.close();
  }
}
