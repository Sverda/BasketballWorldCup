import { createAction, props } from "@ngrx/store";

import { Draw } from "../../model/draw.interface";


export const GetDraw = createAction(
  "[Draw] Get Draw"
);

export const GetDrawSuccess = createAction(
  "[Draw] Get Draw Success",
  props<{ draw: Draw }>()
);

export const AddDraw = createAction(
  "[Draw] Add Draw"
);

export const AddDrawSuccess = createAction(
  "[Draw] Add Draw Success",
  props<{ draw: Draw }>()
);

export const UpdateDrawWithGroups = createAction(
  "[Draw] Update Draw With Groups"
);

export const UpdateDrawWithGroupsSuccess = createAction(
  "[Draw] Update Draw With Groups Success",
  props<{ draw: Draw }>()
);
