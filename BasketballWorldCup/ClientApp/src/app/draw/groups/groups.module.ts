import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { MultiFormSharedModule } from "../../multi-form-shared/multi-form-shared.module";
import { GroupsComponent } from "./groups.component";


@NgModule({
  declarations: [GroupsComponent],
  imports: [
    CommonModule,
    MultiFormSharedModule,
    RouterModule.forChild([{ path: "", component: GroupsComponent }])
  ],
  exports: [GroupsComponent]
})
export class GroupsModule { }
