import { Action } from "@ngrx/store";

import { Team } from "../../services/teams.service";


export const ADD_TEAM = "ADD_TEAM";

export class AddTeam implements Action {
  readonly type = ADD_TEAM;
  payload: Team;
}
