import { Team } from "../../model/team.interface";

export interface TeamState {
  teams: Team[];
}


export const initialTeamState: TeamState =
{
  teams: null
}
