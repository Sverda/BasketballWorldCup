import { createAction, props } from "@ngrx/store";

import { GroupResult } from "../../model/group-result.interface";


export const GetFirstRound = createAction(
  "[First Round] Get First Round"
);

export const GetFirstRoundSuccess = createAction(
  "[First Round] Get First Round Success",
  props<{ groupsResult: GroupResult[] }>()
);
