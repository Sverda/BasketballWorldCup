import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { StoreModule } from "@ngrx/store";
import { StoreDevtoolsModule } from "@ngrx/store-devtools";
import { EffectsModule } from "@ngrx/effects";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { AppRoutingModule } from "./app-routing.module";
import * as fromTeam from "./store/reducers/team.reducer";
import { TeamEffects } from "./store/effects/team.effects";
import * as fromDraw from "./store/reducers/draw.reducer";
import { DrawEffects } from "./store/effects/draw.effects";
import * as fromRounds from "./store/reducers/rounds.reducer";
import { RoundsEffects } from "./store/effects/rounds.effects";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    EffectsModule.forRoot([TeamEffects, DrawEffects, RoundsEffects]),
    StoreModule.forRoot({ team: fromTeam.reducer, draw: fromDraw.reducer, rounds: fromRounds.reducer }),
    StoreDevtoolsModule.instrument({
      maxAge: 25
    }),
    AppRoutingModule
  ],
  exports: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
