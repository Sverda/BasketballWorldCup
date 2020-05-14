import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { FirstRoundComponent } from "./first-round.component";
import { MultiFormSharedModule } from "../../multi-form-shared/multi-form-shared.module";


@NgModule({
  declarations: [FirstRoundComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: "", component: FirstRoundComponent }])
  ]
})
export class FirstRoundModule { }
