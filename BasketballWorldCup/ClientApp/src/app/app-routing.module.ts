import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: 'teams-manager',
    loadChildren: () => import('./teams-manager/teams-manager.module').then(m => m.TeamsManagerModule)
  },
  {
    path: 'select-teams', 
    loadChildren: () => import('./select-teams/select-teams.module').then(m => m.SelectTeamsModule)
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
