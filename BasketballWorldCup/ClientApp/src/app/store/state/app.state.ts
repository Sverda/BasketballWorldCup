import { RouterReducerState } from "@ngrx/router-store";

import { TeamState, initialTeamState } from "./team.state";
import { DrawState, initialDrawState } from "./draw.state";
import { RoundsState, initialRoundsState } from "./rounds.state";


export interface AppState {
  router?: RouterReducerState;
  team: TeamState;
  draw: DrawState;
  rounds: RoundsState;
}

export const initialAppState = {
  team: initialTeamState,
  draw: initialDrawState,
  rounds: initialRoundsState
}

export function getInitialState(): AppState {
  return initialAppState;
}
