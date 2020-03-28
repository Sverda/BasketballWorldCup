import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TeamsManagerComponent } from "./teams-manager.component";
import { AddTeamModule } from "../add-team/add-team.module";
import { MatIconModule } from "@angular/material";


@NgModule({
  declarations: [TeamsManagerComponent],
  imports: [
    CommonModule,
    MatIconModule,
    RouterModule.forChild([{ path: '', component: TeamsManagerComponent }]),
    AddTeamModule
  ],
  exports: [
    TeamsManagerComponent
  ]
})
export class TeamsManagerModule { }
