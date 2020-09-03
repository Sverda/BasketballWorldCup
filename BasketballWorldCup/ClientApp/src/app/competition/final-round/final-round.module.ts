import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { FinalRoundComponent } from "./final-round.component";
import { MultiFormSharedModule } from "../../multi-form-shared/multi-form-shared.module";


@NgModule({
  declarations: [FinalRoundComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: "", component: FinalRoundComponent }])
  ]
})
export class FinalRoundModule { }
