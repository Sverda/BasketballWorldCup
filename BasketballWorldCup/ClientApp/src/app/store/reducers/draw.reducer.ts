import { Action, createReducer, on } from "@ngrx/store";

import { DrawState, initialDrawState } from "../state/draw.state";
import * as DrawActions from "../actions/draw.actions";


const drawReducer = createReducer(
  initialDrawState,
  on(DrawActions.GetDraw,
    state => ({
      ...state
    })),
  on(DrawActions.GetDrawSuccess,
    (state, { draw }) => ({
      ...state,
      draw: draw
    })),
  on(DrawActions.AddDrawSuccess,
    (state, { draw }) => ({
      ...state,
      draw: draw
    })),
  on(DrawActions.UpdateDrawWithGroupsSuccess,
    (state, { draw }) => ({
      ...state,
      draw: {
        pots: [...state.draw.pots],
        groups: draw.groups
      }
    }))
);

export function reducer(state: DrawState | undefined, action: Action) {
  return drawReducer(state, action);
}
