import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { SelectTeamsModule } from "../select-teams.module";
import { AmericasSelectTeamsComponent } from "./americas-select-teams.component";



@NgModule({
  declarations: [AmericasSelectTeamsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SelectTeamsModule,
    RouterModule.forChild([{ path: "", component: AmericasSelectTeamsComponent }]),
  ],
  exports: [AmericasSelectTeamsComponent]
})
export class AmericasSelectTeamsModule { }
