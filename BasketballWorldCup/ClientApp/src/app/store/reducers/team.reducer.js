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
var store_1 = require("@ngrx/store");
var team_state_1 = require("../state/team.state");
var TeamActions = require("../actions/team.actions");
var teamReducer = store_1.createReducer(team_state_1.initialTeamState, store_1.on(TeamActions.GetTeams, function (state) { return (__assign(__assign({}, state), { teams: state.teams })); }), store_1.on(TeamActions.GetTeamsSuccess, function (state, _a) {
    var teams = _a.teams;
    return (__assign(__assign({}, state), { teams: teams }));
}));
function reducer(state, action) {
    return teamReducer(state, action);
}
exports.reducer = reducer;
//# sourceMappingURL=team.reducer.js.map