import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MultiFormHeaderComponent } from './multi-form-header/multi-form-header.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [MultiFormHeaderComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([])
  ],
  exports: [
    MultiFormHeaderComponent
  ]
})
export class CoreModule { }
