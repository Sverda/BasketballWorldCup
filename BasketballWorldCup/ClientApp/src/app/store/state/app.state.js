"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var team_state_1 = require("./team.state");
exports.initialAppState = {
    teams: team_state_1.initialTeamState
};
function getInitialState() {
    return exports.initialAppState;
}
exports.getInitialState = getInitialState;
//# sourceMappingURL=app.state.js.map