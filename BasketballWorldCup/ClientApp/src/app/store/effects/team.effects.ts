import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType, ROOT_EFFECTS_INIT } from "@ngrx/effects";
import { map, mergeMap, tap } from "rxjs/operators";

import { TeamsService } from "../../services/teams.service";
import { TeamState } from "../state/team.state";
import { GetTeams, GetTeamsSuccess } from "../actions/team.actions";


@Injectable()
export class TeamEffects {
  constructor(private teamService: TeamsService, private actions$: Actions) { }

  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ROOT_EFFECTS_INIT),
      mergeMap(
        () => this.teamService.getTeams().pipe(
          tap(() => console.log("init")),
          map(teams => GetTeamsSuccess({ teams: teams }))
        )
      )
    )
  );

  getTeamsEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(GetTeams),
      mergeMap(
        () => this.teamService.getTeams().pipe(
          map(teams => GetTeamsSuccess({ teams: teams }))
        )
      )
    )
  )
}
