"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var store_1 = require("@ngrx/store");
exports.GetTeams = store_1.createAction("[Teams] Get Teams");
exports.GetTeamsSuccess = store_1.createAction("[Teams] Get Teams Success", store_1.props());
exports.AddTeam = store_1.createAction("[Teams] Add Team", store_1.props());
exports.AddTeamSuccess = store_1.createAction("[Teams] Add Team Success", store_1.props());
exports.DeleteTeam = store_1.createAction("[Teams] Delete Team", store_1.props());
exports.DeleteTeamSuccess = store_1.createAction("[Teams] Delete Team Success", store_1.props());
//# sourceMappingURL=team.actions.js.map