import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AfricaSelectTeamsComponent } from "./africa-select-teams.component";
import { SelectTeamsModule } from "../select-teams.module";


@NgModule({
  declarations: [AfricaSelectTeamsComponent],
  imports: [
    CommonModule,
    SelectTeamsModule
  ],
  exports: [AfricaSelectTeamsComponent]
})
export class AfricaSelectTeamsModule { }
