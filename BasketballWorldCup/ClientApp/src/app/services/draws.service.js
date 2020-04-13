"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var DrawsService = /** @class */ (function () {
    function DrawsService(http, baseUrl) {
        this.http = http;
        this.drawsUrl = "api/draws";
        this.baseUrl = baseUrl;
    }
    DrawsService.prototype.addDraw = function (teams) {
        var httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': "application/json"
            })
        };
        return this.http.post(this.baseUrl + this.drawsUrl, teams, httpOptions);
    };
    DrawsService = __decorate([
        core_1.Injectable({ providedIn: "root" }),
        __param(1, core_1.Inject("BASE_URL"))
    ], DrawsService);
    return DrawsService;
}());
exports.DrawsService = DrawsService;
//# sourceMappingURL=draws.service.js.map