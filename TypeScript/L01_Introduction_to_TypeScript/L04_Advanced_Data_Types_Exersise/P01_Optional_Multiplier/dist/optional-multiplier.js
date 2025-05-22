"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function optionalMultipier(param1, param2, param3) {
    let num1 = param1 == undefined ? 1 : Number(param1);
    let num2 = param2 == undefined ? 1 : Number(param2);
    let num3 = param3 == undefined ? 1 : Number(param3);
    return num1 * num2 * num3;
}
console.log(optionalMultipier('3', '5', '10'));
console.log(optionalMultipier('2', '2'));
console.log(optionalMultipier(undefined, 2, 3));
console.log(optionalMultipier(7, undefined, '2'));
console.log(optionalMultipier());
//# sourceMappingURL=optional-multiplier.js.map