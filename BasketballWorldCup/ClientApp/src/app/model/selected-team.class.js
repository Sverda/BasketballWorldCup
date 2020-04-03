"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SelectedTeam = /** @class */ (function () {
    function SelectedTeam(data) {
        this.data = data;
        this.unselect();
    }
    SelectedTeam.prototype.isSelected = function () {
        return this.selected;
    };
    SelectedTeam.prototype.select = function () {
        this.selected = true;
    };
    SelectedTeam.prototype.unselect = function () {
        this.selected = false;
    };
    return SelectedTeam;
}());
exports.SelectedTeam = SelectedTeam;
//# sourceMappingURL=commons.js.map