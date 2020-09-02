import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { SecondRoundComponent } from "./second-round.component";
import { MultiFormSharedModule } from "../../multi-form-shared/multi-form-shared.module";


@NgModule({
  declarations: [SecondRoundComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: "", component: SecondRoundComponent }])
  ]
})
export class SecondRoundModule { }
