import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { InstructionComponent } from "./instruction.component";


@NgModule({
  declarations: [InstructionComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: "", component: InstructionComponent }])
  ],
  exports: [
    InstructionComponent
  ]
})
export class InstructionModule { }
