import { TeamSummary } from "./team-summary.interface";

export interface GroupSummary {
  groupLetter: string;
  summaries: TeamSummary[];
}
