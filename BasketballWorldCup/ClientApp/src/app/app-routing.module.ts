import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'simulation',
    loadChildren: () => import('./simulation/simulation.module').then(m => m.SimulationModule)
  },
  {
    path: 'teams-manager',
    loadChildren: () => import('./teams-manager/teams-manager.module').then(m => m.TeamsManagerModule)
  },
  {
    path: '',
    redirectTo: 'simulation',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
