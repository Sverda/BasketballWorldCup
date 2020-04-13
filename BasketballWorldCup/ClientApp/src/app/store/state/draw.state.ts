import { Draw } from "../../model/draw.interface";

export interface DrawState {
  draw: Draw;
}


export const initialDrawState: DrawState =
{
  draw: null
}
