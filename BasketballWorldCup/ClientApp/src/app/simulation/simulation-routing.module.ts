import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SimulationComponent } from "./simulation.component";

const routes: Routes = [
  {
    path: '',
    component: SimulationComponent,
    children: [
      {
        path: 'select-teams/:zoneId',
        loadChildren: () => import('../select-teams/select-teams.module').then(m => m.SelectTeamsModule)
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
