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
      },
      {
        path: "europe",
        loadChildren: () => import("../select-teams/europe-select-teams/europe-select-teams.module").then(m => m.EuropeSelectTeamsModule)
      },
      {
        path: "americas",
        loadChildren: () => import("../select-teams/americas-select-teams/americas-select-teams.module").then(m => m.AmericasSelectTeamsModule)
      },
      {
        path: "asia",
        loadChildren: () => import("../select-teams/asia-select-teams/asia-select-teams.module").then(m => m.AsiaSelectTeamsModule)
      },
      {
        path: "pots",
        loadChildren: () => import("../draw/pots/pots.module").then(m => m.PotsModule)
      },
      {
        path: "groups",
        loadChildren: () => import("../draw/groups/groups.module").then(m => m.GroupsModule)
      },
      {
        path: "first-round",
        loadChildren: () => import("../competition/first-round/first-round.module").then(m => m.FirstRoundModule)
      },
      {
        path: "second-round",
        loadChildren: () => import("../competition/second-round/second-round.module").then(m => m.SecondRoundModule)
      },
      {
        path: "final-round",
        loadChildren: () => import("../competition/final-round/final-round.module").then(m => m.FinalRoundModule)
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
