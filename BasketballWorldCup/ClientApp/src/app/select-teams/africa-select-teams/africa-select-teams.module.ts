import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AfricaSelectTeamsComponent } from "./africa-select-teams.component";
import { SelectTeamsModule } from "../select-teams.module";


@NgModule({
  declarations: [AfricaSelectTeamsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SelectTeamsModule,
    RouterModule.forChild([{ path: "", component: AfricaSelectTeamsComponent }]),
  ],
  exports: [AfricaSelectTeamsComponent]
})
export class AfricaSelectTeamsModule { }
