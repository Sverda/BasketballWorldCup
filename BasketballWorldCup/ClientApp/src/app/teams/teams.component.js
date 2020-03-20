"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var TeamsComponent = /** @class */ (function () {
    function TeamsComponent(teamsService) {
        this.teamsService = teamsService;
        this.teamsByTier = [];
        this.showTeamsByTier(0);
        this.showTeamsByTier(1);
        this.showTeamsByTier(2);
        this.showTeamsByTier(3);
        this.selectedTeams = [];
    }
    TeamsComponent.prototype.showTeamsByTier = function (tier) {
        var _this = this;
        this.teamsService.getTeamsByTier(tier).subscribe(function (result) { _this.teamsByTier[tier] = result; }, function (error) { return console.error(error); });
    };
    TeamsComponent.prototype.onTeamSelect = function (team) {
        if (this.selectedTeams.filter(function (t) { return t.id === team.id; }).length > 0) {
            this.selectedTeams = this.selectedTeams.filter(function (t) { return t.id !== team.id; });
        }
        else {
            this.selectedTeams.push(team);
        }
    };
    TeamsComponent.prototype.isActive = function (team) {
        return this.selectedTeams.filter(function (t) { return t.id === team.id; }).length > 0;
    };
    TeamsComponent = __decorate([
        core_1.Component({
            selector: 'app-teams',
            templateUrl: './teams.component.html',
        })
    ], TeamsComponent);
    return TeamsComponent;
}());
exports.TeamsComponent = TeamsComponent;
//# sourceMappingURL=teams.component.js.map