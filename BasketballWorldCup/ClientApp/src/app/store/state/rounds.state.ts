import { GroupResult } from "../../model/group-result.interface";

export interface RoundsState {
  firstRound: GroupResult[];
}


export const initialRoundsState: RoundsState =
{
  firstRound: null
}
