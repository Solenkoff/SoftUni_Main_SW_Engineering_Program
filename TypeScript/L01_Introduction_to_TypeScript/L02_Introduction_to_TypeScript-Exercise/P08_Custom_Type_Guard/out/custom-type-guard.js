"use strict";
function isNonEmptyStringArray(arg) {
    return Array.isArray(arg) && arg.length > 0 && arg.every(el => typeof el === 'string');
}
// let arr: unknown = {};
// let arr: unknown = { test: 'one' };
// let arr: unknown = [];
// let arr: unknown = undefined;
// let arr: unknown = null;
// let arr: unknown = [12, 13];
// let arr: unknown = ['test', 123];
let arr = ['a', 'b', 'c'];
if (isNonEmptyStringArray(arr)) {
    console.log(arr.length); // allowed
}
// console.log(isNonEmptyStringArray({}));
// console.log(isNonEmptyStringArray({ test: 'one' }));
// console.log(isNonEmptyStringArray([]));
// console.log(isNonEmptyStringArray(undefined));
// console.log(isNonEmptyStringArray(null));
// console.log(isNonEmptyStringArray([12, 13]));
// console.log(isNonEmptyStringArray(['test', 123]));
// console.log(isNonEmptyStringArray(['a', 'b', 'c']));
//# sourceMappingURL=custom-type-guard.js.map