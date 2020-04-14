import { Draw } from "../../model/draw.interface";

export interface DrawState {
  draw: Draw;
}


export const initialDrawState: DrawState =
{
  draw: {
    id: 0,
    pots: null,
    groups: null
  }
}
