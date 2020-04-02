import { Action } from "@ngrx/store";

import * as SelectTeamsActions from "./select-teams.actions";


const initialState = {
  teams: [],
  africaTeams: [],
  europeTeams: [],
  americasTeams: [],
  asiaTeams: [],
};

export function selectTeamsReducer(state = initialState, action: SelectTeamsActions.AddTeam) {
  switch (action.type) {
    case SelectTeamsActions.ADD_TEAM:
    {
      return {
        ...state,
        teams: [...state.teams, action.payload]
      };
    }
  }
}
