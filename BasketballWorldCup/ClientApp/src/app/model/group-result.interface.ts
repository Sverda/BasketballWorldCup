import { MatchResult } from "./match-result.interface";
import { TeamSummary } from "./team-summary.interface";

export interface GroupResult {
  groupLetter: string;
  matchResults: MatchResult[];
  summaries: TeamSummary[];
}
