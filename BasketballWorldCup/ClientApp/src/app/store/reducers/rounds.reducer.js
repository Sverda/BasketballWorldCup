"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.reducer = void 0;
var store_1 = require("@ngrx/store");
var RoundsActions = require("../actions/rounds.actions");
var rounds_state_1 = require("../state/rounds.state");
var roundsReducer = store_1.createReducer(rounds_state_1.initialRoundsState, store_1.on(RoundsActions.GetFirstRound, function (state) { return (__assign({}, state)); }), store_1.on(RoundsActions.GetFirstRoundSuccess, function (state, _a) {
    var groupsResult = _a.groupsResult;
    return (__assign(__assign({}, state), { firstRound: groupsResult }));
}), store_1.on(RoundsActions.GetSecondRound, function (state) { return (__assign({}, state)); }), store_1.on(RoundsActions.GetSecondRoundSuccess, function (state, _a) {
    var groupsResult = _a.groupsResult;
    return (__assign(__assign({}, state), { secondRound: groupsResult }));
}), store_1.on(RoundsActions.GetFinalRound, function (state) { return (__assign({}, state)); }), store_1.on(RoundsActions.GetFinalRoundSuccess, function (state, _a) {
    var groupsResult = _a.groupsResult;
    return (__assign(__assign({}, state), { finalRound: groupsResult }));
}));
function reducer(state, action) {
    return roundsReducer(state, action);
}
exports.reducer = reducer;
//# sourceMappingURL=rounds.reducer.js.map