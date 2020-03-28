import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SelectTeamsComponent } from './select-teams.component';
import { MultiFormSharedModule } from '../multi-form-shared/multi-form-shared.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [SelectTeamsComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: '', component: SelectTeamsComponent }]),
    ReactiveFormsModule
  ],
  exports: [
    SelectTeamsComponent
  ]
})
export class SelectTeamsModule { }
