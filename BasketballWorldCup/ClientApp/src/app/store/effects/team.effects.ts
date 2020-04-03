import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType, ROOT_EFFECTS_INIT } from "@ngrx/effects";
import { map, mergeMap } from "rxjs/operators";

import { TeamsService } from "../../services/teams.service";
import { GetTeams, GetTeamsSuccess, AddTeam, AddTeamSuccess } from "../actions/team.actions";


@Injectable()
export class TeamEffects {
  constructor(private teamService: TeamsService, private actions$: Actions) { }

  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ROOT_EFFECTS_INIT),
      mergeMap(
        () => this.teamService.getTeams().pipe(
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

  addTeamEffect$ = createEffect(
    () => this.actions$.pipe(
      ofType(AddTeam),
      mergeMap(
        (action) => this.teamService.addTeam(action.team).pipe(
          map(team => AddTeamSuccess({ team: team }))
        )
      )
    )
  )
}
