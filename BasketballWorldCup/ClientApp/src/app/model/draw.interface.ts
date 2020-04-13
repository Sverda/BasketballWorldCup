import { Pot } from "./pot.interface";
import { Group } from "./group.interface";

export interface Draw {
  id: number;
  pots: Pot[];
  groups: Group[];
}
