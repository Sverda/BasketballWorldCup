import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { HelloComponent } from "./hello.component";


@NgModule({
  declarations: [HelloComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: "", component: HelloComponent }])
  ],
  exports: [
    HelloComponent
  ]
})
export class HelloModule { }
