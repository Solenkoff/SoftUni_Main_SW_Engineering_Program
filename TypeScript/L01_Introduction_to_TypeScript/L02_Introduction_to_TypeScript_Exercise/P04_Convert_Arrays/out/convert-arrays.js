"use strict";
function convertArrays(input) {
    const text = input.join('');
    const length = text.length;
    return [text, length];
}
console.log(convertArrays(['How', 'are', 'you?']));
console.log(convertArrays(['Today', ' is', ' a ', 'nice', ' ', 'day for ', 'TypeScript']));
//# sourceMappingURL=convert-arrays.js.map