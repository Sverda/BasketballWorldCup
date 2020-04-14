"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var effects_1 = require("@ngrx/effects");
var draw_actions_1 = require("../actions/draw.actions");
var DrawEffects = /** @class */ (function () {
    function DrawEffects(actions$, drawsService, store$) {
        var _this = this;
        this.actions$ = actions$;
        this.drawsService = drawsService;
        this.store$ = store$;
        this.addDrawEffect$ = effects_1.createEffect(function () { return _this.actions$.pipe(effects_1.ofType(draw_actions_1.AddDraw)); });
    }
    DrawEffects = __decorate([
        core_1.Injectable()
    ], DrawEffects);
    return DrawEffects;
}());
exports.DrawEffects = DrawEffects;
//# sourceMappingURL=draw.effects.js.map