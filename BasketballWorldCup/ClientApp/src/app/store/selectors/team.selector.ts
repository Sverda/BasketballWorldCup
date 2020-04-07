import { createSelector } from "@ngrx/store";

import { TeamState } from "../state/team.state";


export const selectAfrica = createSelector(
  (state: TeamState) => state,
  (state) => state.africa
);

export const selectEurope = createSelector(
  (state: TeamState) => state,
  (state) => state.europe
);

export const selectAmericas = createSelector(
  (state: TeamState) => state,
  (state) => state.americas
);

export const selectAsia = createSelector(
  (state: TeamState) => state,
  (state) => state.asia
);
