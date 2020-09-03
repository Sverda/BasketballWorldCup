import { createAction, props } from "@ngrx/store";

import { GroupResult } from "../../model/group-result.interface";


export const GetFirstRound = createAction(
  "[First Round] Get First Round"
);

export const GetFirstRoundSuccess = createAction(
  "[First Round] Get First Round Success",
  props<{ groupsResult: GroupResult[] }>()
);

export const GetSecondRound = createAction(
  "[First Round] Get Second Round"
);

export const GetSecondRoundSuccess = createAction(
  "[First Round] Get Second Round Success",
  props<{ groupsResult: GroupResult[] }>()
);

export const GetFinalRound = createAction(
  "[First Round] Get Final Round"
);

export const GetFinalRoundSuccess = createAction(
  "[First Round] Get Final Round Success",
  props<{ groupsResult: GroupResult[] }>()
);
