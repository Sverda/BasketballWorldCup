import { Team } from "./team.interface";

export interface Group {
  id: number;
  letter: string;
  teams: Team[];
}
