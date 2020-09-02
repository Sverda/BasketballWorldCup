"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getInitialState = exports.initialAppState = void 0;
var team_state_1 = require("./team.state");
var draw_state_1 = require("./draw.state");
var rounds_state_1 = require("./rounds.state");
exports.initialAppState = {
    team: team_state_1.initialTeamState,
    draw: draw_state_1.initialDrawState,
    rounds: rounds_state_1.initialRoundsState
};
function getInitialState() {
    return exports.initialAppState;
}
exports.getInitialState = getInitialState;
//# sourceMappingURL=app.state.js.map