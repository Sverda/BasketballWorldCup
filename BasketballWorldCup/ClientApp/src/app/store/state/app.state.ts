import { RouterReducerState } from "@ngrx/router-store";

import { TeamState, initialTeamState } from "./team.state";
import { DrawState, initialDrawState } from "./draw.state";


export interface AppState {
  router?: RouterReducerState;
  team: TeamState;
  draw: DrawState;
}

export const initialAppState = {
  team: initialTeamState,
  draw: initialDrawState
}

export function getInitialState(): AppState {
  return initialAppState;
}
