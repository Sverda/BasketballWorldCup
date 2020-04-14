"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var team_state_1 = require("./team.state");
var draw_state_1 = require("./draw.state");
exports.initialAppState = {
    team: team_state_1.initialTeamState,
    draw: draw_state_1.initialDrawState
};
function getInitialState() {
    return exports.initialAppState;
}
exports.getInitialState = getInitialState;
//# sourceMappingURL=app.state.js.map