import { Action, createReducer, on } from '@ngrx/store';

import { initialTeamState } from "../state/team.state";
import { TeamState } from "../state/team.state";
import * as TeamActions from "../actions/team.actions";


const teamReducer = createReducer(
  initialTeamState,
  on(TeamActions.GetTeams, state => ({
    ...state,
    teams: state.teams
  })),
  on(TeamActions.GetTeamsSuccess, (state, { teams }) => ({
    ...state,
    teams: teams
  }))
);

export function reducer(state: TeamState | undefined, action: Action) {
  return teamReducer(state, action);
}
