/* Options:
Date: 2021-02-10 05:16:52
Version: 5.105
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//GlobalNamespace:
//MakePropertiesOptional: False
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion:
//AddDescriptionAsComments: True
//IncludeTypes:
//ExcludeTypes:
//DefaultImports:
*/
(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports"], factory);
    }
})(function (require, exports) {
    "use strict";
    exports.__esModule = true;
    exports.Hello = exports.HelloResponse = void 0;
    var HelloResponse = /** @class */ (function () {
        function HelloResponse(init) {
            Object.assign(this, init);
        }
        return HelloResponse;
    }());
    exports.HelloResponse = HelloResponse;
    // @Route("/hello")
    // @Route("/hello/{Name}")
    var Hello = /** @class */ (function () {
        function Hello(init) {
            Object.assign(this, init);
        }
        Hello.prototype.createResponse = function () { return new HelloResponse(); };
        Hello.prototype.getTypeName = function () { return 'Hello'; };
        return Hello;
    }());
    exports.Hello = Hello;
});
