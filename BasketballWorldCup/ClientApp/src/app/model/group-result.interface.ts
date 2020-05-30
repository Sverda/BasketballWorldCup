import { MatchResult } from "./match-result.interface";
import { GroupSummary } from "./group-summary.interface";

export interface GroupResult {
  groupLetter: string;
  matchResults: MatchResult[];
  groupSummary: GroupSummary;
}
