import { Store, Action } from "@ngrx/store";
import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { map, mergeMap, withLatestFrom } from "rxjs/operators";

import { AppState } from "../state/app.state";
import { RoundsService } from "../../services/rounds.service";
import { GetFirstRound, GetFirstRoundSuccess, GetSecondRound, GetSecondRoundSuccess } from "../actions/rounds.actions";


@Injectable()
export class RoundsEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly roundsService: RoundsService,
    private readonly store$: Store<AppState>
  ) { }

  addFirstRoundEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(GetFirstRound),
      withLatestFrom(this.store$),
      mergeMap(([action, storeState]: [Action, AppState]) => this.roundsService.getFirstRound(storeState.draw.draw.id).pipe(map(results => GetFirstRoundSuccess({ groupsResult: results }))))
    )
  );

  addSecondRoundEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(GetSecondRound),
      withLatestFrom(this.store$),
      mergeMap(([action, storeState]: [Action, AppState]) => this.roundsService.getSecondRound(storeState.draw.draw.id).pipe(map(results => GetSecondRoundSuccess({ groupsResult: results }))))
    )
  );
}
