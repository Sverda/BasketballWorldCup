import { Action, createReducer, on } from '@ngrx/store';

import { initialTeamState } from "../state/team.state";
import { TeamState } from "../state/team.state";
import * as TeamActions from "../actions/team.actions";
import { Team } from "../../model/team.interface";
import SelectOrUnselectTeam = TeamActions.SelectOrUnselectTeam;


function updateTeamInArray(array: Team[], selectedTeam: Team) {
  return array.map((team) => {
    if (team.id !== selectedTeam.id) {
      return team;
    } else {
      return {
        ...selectedTeam
      };
    }
  });
}

const teamReducer = createReducer(
  initialTeamState,
  on(TeamActions.GetTeams,
    state => ({
      ...state
    })),
  on(TeamActions.GetTeamsSuccess,
    (state, { teams }) => ({
      ...state,
      teams: teams
    })),
  on(TeamActions.AddTeamSuccess,
    (state, { team }) => ({
      ...state,
      teams: [...state.teams, team]
    })),
  on(TeamActions.DeleteTeamSuccess,
    (state, { team }) => ({
      ...state,
      teams: state.teams.filter(t => t.id !== team.id)
    })),
  on(SelectOrUnselectTeam, (state, { team }) => ({
    ...state,
    teams: updateTeamInArray(state.teams, team)
  }))
);

export function reducer(state: TeamState | undefined, action: Action) {
  return teamReducer(state, action);
}
