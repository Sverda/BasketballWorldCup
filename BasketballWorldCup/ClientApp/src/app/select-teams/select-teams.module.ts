import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SelectTeamsComponent } from "./select-teams.component";
import { MultiFormSharedModule } from "../multi-form-shared/multi-form-shared.module";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { RandomSelectComponent } from "./random-select/random-select.component";


@NgModule({
  declarations: [
    SelectTeamsComponent,
    RandomSelectComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule
  ],
  exports: [
    SelectTeamsComponent
  ]
})
export class SelectTeamsModule { }
