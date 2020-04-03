import { createAction, props } from "@ngrx/store";

import { Team } from "../../model/team.interface";


export const GetTeams = createAction(
  "[Teams] Get Teams"
);

export const GetTeamsSuccess = createAction(
  "[Teams] Get Teams Success",
  props<{ teams: Team[] }>()
);

export const AddTeam = createAction(
  "[Teams] Add Team",
  props<{team: Team}>()
);

export const AddTeamSuccess = createAction(
  "[Teams] Add Team Success",
  props<{ team: Team }>()
);

export const DeleteTeam = createAction(
  "[Teams] Delete Team",
  props<{ teamId: number }>()
);

export const DeleteTeamSuccess = createAction(
  "[Teams] Delete Team Success",
  props<{ team: Team }>()
);
