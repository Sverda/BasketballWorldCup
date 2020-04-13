import { Store, Action } from '@ngrx/store';
import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { filter, map, mergeMap, withLatestFrom } from "rxjs/operators";

import { DrawsService } from "../../services/draws.service";
import { AddDraw, AddDrawSuccess } from "../actions/draw.actions";
import { AppState } from "../state/app.state";
import { TeamState } from "../state/team.state";


@Injectable()
export class DrawEffects {
  constructor(
    private actions$: Actions,
    private drawsService: DrawsService,
    private store$: Store<AppState>
  ) { }

  addDrawEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(AddDraw),
      withLatestFrom(this.store$),
      mergeMap(([action, storeState]: [Action, AppState]) => this.drawsService.addDraw(storeState.team.teams.filter(t => t.isSelected)).pipe(map(draw => AddDrawSuccess({ draw: draw }))))
    )
  )
}
