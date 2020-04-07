import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { SelectTeamsModule } from "../select-teams.module";
import { EuropeSelectTeamsComponent } from "./europe-select-teams.component";



@NgModule({
  declarations: [EuropeSelectTeamsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SelectTeamsModule,
    RouterModule.forChild([{ path: "", component: EuropeSelectTeamsComponent }]),
  ],
  exports: [EuropeSelectTeamsComponent]
})
export class EuropeSelectTeamsModule { }
