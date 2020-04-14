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
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var store_1 = require("@ngrx/store");
var draw_state_1 = require("../state/draw.state");
var DrawActions = require("../actions/draw.actions");
var drawReducer = store_1.createReducer(draw_state_1.initialDrawState, store_1.on(DrawActions.GetDraw, function (state) { return (__assign({}, state)); }), store_1.on(DrawActions.GetDrawSuccess, function (state, _a) {
    var draw = _a.draw;
    return (__assign(__assign({}, state), { draw: draw }));
}), store_1.on(DrawActions.AddDrawSuccess, function (state, _a) {
    var draw = _a.draw;
    return (__assign(__assign({}, state), { draw: __assign(__assign({}, state.draw), { id: draw.id, pots: draw.pots }) }));
}), store_1.on(DrawActions.UpdateDrawWithGroupsSuccess, function (state, _a) {
    var draw = _a.draw;
    return (__assign(__assign({}, state), { draw: __assign(__assign({}, state.draw), { pots: __spreadArrays(state.draw.pots), groups: draw.groups }) }));
}));
function reducer(state, action) {
    return drawReducer(state, action);
}
exports.reducer = reducer;
//# sourceMappingURL=draw.reducer.js.map