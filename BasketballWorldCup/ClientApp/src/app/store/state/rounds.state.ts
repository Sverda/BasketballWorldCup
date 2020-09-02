import { GroupResult } from "../../model/group-result.interface";

export interface RoundsState {
  firstRound: GroupResult[];
  secondRound: GroupResult[];
}


export const initialRoundsState: RoundsState =
{
  firstRound: null,
  secondRound: null
}
