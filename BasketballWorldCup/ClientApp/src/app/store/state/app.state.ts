import { RouterReducerState } from "@ngrx/router-store";

import { TeamState, initialTeamState } from "./team.state";


export interface AppState {
  router?: RouterReducerState;
  teams: TeamState;
}

export const initialAppState = {
  teams: initialTeamState
}

export function getInitialState(): AppState {
  return initialAppState;
}
