import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SimulationComponent } from './simulation.component';
import { CoreModule } from "../core/core.module";
import { ReactiveFormsModule } from '@angular/forms';
import { SimulationRoutingModule } from "./simulation-routing.module";


@NgModule({
  declarations: [SimulationComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CoreModule,
    SimulationRoutingModule
  ],
  exports: [
    SimulationComponent
  ]
})
export class SimulationModule { }
