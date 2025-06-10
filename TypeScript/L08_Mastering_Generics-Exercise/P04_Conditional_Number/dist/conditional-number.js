"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function conditionalNumber(param) {
    if (typeof param === 'number') {
        console.log(param.toFixed(2));
    }
    else {
        console.log(param);
    }
}
conditionalNumber(20.3555);
conditionalNumber('wow');
conditionalNumber('a string');
//# sourceMappingURL=conditional-number.js.map