import { Store, Action } from "@ngrx/store";
import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { map, mergeMap, withLatestFrom } from "rxjs/operators";

import { DrawsService } from "../../services/draws.service";
import { AddDraw, AddDrawSuccess, UpdateDrawWithGroups, UpdateDrawWithGroupsSuccess } from "../actions/draw.actions";
import { AppState } from "../state/app.state";


@Injectable()
export class DrawEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly drawsService: DrawsService,
    private readonly store$: Store<AppState>
  ) { }

  addDrawEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(AddDraw),
      withLatestFrom(this.store$),
      mergeMap(([action, storeState]: [Action, AppState]) => this.drawsService.addDraw(storeState.team.teams.filter(t => t.isSelected)).pipe(map(draw => AddDrawSuccess({ draw: draw }))))
    )
  )

  updateDrawWithGroupsEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(UpdateDrawWithGroups),
      withLatestFrom(this.store$),
      mergeMap(([action, storeState]: [Action, AppState]) => this.drawsService.updateDrawWithGroups(storeState.draw.draw).pipe(map(draw => UpdateDrawWithGroupsSuccess({ draw: draw }))))
    )
  )
}
