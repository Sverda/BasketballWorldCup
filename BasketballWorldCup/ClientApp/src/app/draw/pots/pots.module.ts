import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { PotsComponent } from "./pots.component";
import { MultiFormSharedModule } from "../../multi-form-shared/multi-form-shared.module";



@NgModule({
  declarations: [PotsComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: "", component: PotsComponent }])
  ],
  exports: [PotsComponent]
})
export class PotsModule { }
