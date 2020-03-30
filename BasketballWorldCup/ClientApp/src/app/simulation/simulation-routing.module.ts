import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SimulationComponent } from "./simulation.component";

const routes: Routes = [
  {
    path: "",
    component: SimulationComponent,
    children: [
      {
        path: "africa",
        loadChildren: () => import("../select-teams/africa-select-teams/africa-select-teams.module").then(m => m.AfricaSelectTeamsModule)
      }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class SimulationRoutingModule { }
