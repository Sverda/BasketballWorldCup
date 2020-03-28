import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { TeamsManagerComponent } from "./teams-manager/teams-manager.component";
import { TeamsManagerModule } from "./teams-manager/teams-manager.module";
import { SelectTeamsComponent } from "./select-teams/select-teams.component";
import { SelectTeamsModule } from "./select-teams/select-teams.module";
import { AddTeamModule } from "./add-team/add-team.module";

const routes: Routes = [

  { path: 'teams-manager', component: TeamsManagerComponent },
  { path: 'select-teams', component: SelectTeamsComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TeamsManagerModule,
    SelectTeamsModule,
    AddTeamModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
