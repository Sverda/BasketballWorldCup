"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GetSecondRoundSuccess = exports.GetSecondRound = exports.GetFirstRoundSuccess = exports.GetFirstRound = void 0;
var store_1 = require("@ngrx/store");
exports.GetFirstRound = store_1.createAction("[First Round] Get First Round");
exports.GetFirstRoundSuccess = store_1.createAction("[First Round] Get First Round Success", store_1.props());
exports.GetSecondRound = store_1.createAction("[First Round] Get Second Round");
exports.GetSecondRoundSuccess = store_1.createAction("[First Round] Get Second Round Success", store_1.props());
//# sourceMappingURL=rounds.actions.js.map