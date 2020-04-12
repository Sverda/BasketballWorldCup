import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { SelectTeamsModule } from "../select-teams.module";
import { AsiaSelectTeamsComponent } from "./asia-select-teams.component";



@NgModule({
  declarations: [AsiaSelectTeamsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SelectTeamsModule,
    RouterModule.forChild([{ path: "", component: AsiaSelectTeamsComponent }]),
  ],
  exports: [AsiaSelectTeamsComponent]
})
export class AsiaSelectTeamsModule { }
