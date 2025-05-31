"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Calculator {
    calculate(operation, num1, num2, num3, num4) {
        let validNums = [num1, num2, num3, num4].filter(num => num !== undefined);
        switch (operation) {
            case 'power': return Math.pow(num1, num2); //*   num1**num2
            case 'log':
                if (num1 <= 0 || num2 <= 0 || num1 === 1) {
                    throw new Error('Invalid parameters!');
                }
                return Math.log(num1) / Math.log(num2);
            case 'add': return validNums.reduce((acc, val) => acc + val);
            case 'subtract': return validNums.reduce((acc, val) => acc - val);
            case 'multiply': return validNums.reduce((acc, val) => acc * val);
            case 'divide':
                if (validNums.slice(1).some(num => num === 0)) {
                    throw new Error('Can NOT divide by 0!');
                }
                return validNums.reduce((acc, val) => acc / val);
        }
    }
}
// const calc = new Calculator();
// console.log(calc.calculate('power', 2, 3));
// console.log(calc.calculate('power', 4, 1/2));
// console.log(calc.calculate('log', 8, 2));
// console.log(calc.calculate('add', 10, 5));
// console.log(calc.calculate('add', 10, 5, 3));
// console.log(calc.calculate('subtract', 10, 5));
// console.log(calc.calculate('multiply', 2, 3, 4));
// console.log(calc.calculate('divide', 100, 5, 2, 2));
const calc = new Calculator();
//console.log(calc.calculate('power', 2, 3, 2));
console.log(calc.calculate('add', 2));
// console.log(calc.calculate('log', 2, 3, 4, 5)); 
// console.log(calc.calculate('multiply', 2, 3, 4, 5, 6));
//# sourceMappingURL=overlaoded-calcularor.js.map