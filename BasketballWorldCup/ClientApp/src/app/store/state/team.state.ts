import { Team } from "../../model/team.interface";

export interface TeamState {
  teams: Team[];
  africa: Team[];
  europe: Team[];
  americas: Team[];
  asia: Team[];
}


export const initialTeamState: TeamState =
{
  teams: null,
  africa: null,
  europe: null,
  americas: null,
  asia: null
}
