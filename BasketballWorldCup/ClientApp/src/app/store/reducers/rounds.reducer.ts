import { Action, createReducer, on } from "@ngrx/store";

import * as RoundsActions from "../actions/rounds.actions";
import { RoundsState, initialRoundsState } from "../state/rounds.state";


const roundsReducer = createReducer(
  initialRoundsState,
  on(RoundsActions.GetFirstRound,
    state => ({
      ...state
    })),
  on(RoundsActions.GetFirstRoundSuccess,
    (state, { groupsResult }) => ({
      ...state,
      firstRound: groupsResult
    })),
  on(RoundsActions.GetSecondRound,
    state => ({
      ...state
    })),
  on(RoundsActions.GetSecondRoundSuccess,
    (state, { groupsResult }) => ({
      ...state,
      secondRound: groupsResult
    }))
);

export function reducer(state: RoundsState | undefined, action: Action) {
  return roundsReducer(state, action);
}
