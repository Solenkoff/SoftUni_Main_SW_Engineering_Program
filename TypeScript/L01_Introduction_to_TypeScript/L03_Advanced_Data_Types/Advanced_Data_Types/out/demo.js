"use strict";
//*    Union Tupes   
function printGreeting(text) {
    if (typeof text === 'string') {
        console.log(text);
    }
    else {
        console.log(text.join(' '));
    }
}
printGreeting('Hello Sol!');
printGreeting(['Hello', 'its', 'me!']);
//*   Intersection Types
//   Farther Down
//*   Literal Types
let passFailedGrade;
passFailedGrade = 'pass';
passFailedGrade = 'fail';
// passFailedGrade = 'Excellent';    //!  Error
console.log(passFailedGrade);
let numericGrade;
numericGrade = 3;
numericGrade = 6;
// numericGrade = 8;    //!  Error
console.log(numericGrade);
function printStudentInfo(student) {
    if (student.gpa) {
        console.log(`Student ${student.firstName} ${student.lastName}, GPA: ${student.gpa}`);
    }
    else {
        console.log(`Student ${student.firstName} ${student.lastName}`);
    }
}
let peshoPerson = {
    firstName: 'Pesho',
    lastName: 'Ivanov',
    age: 17
};
let solPerson = {
    firstName: 'Sol',
    lastName: 'Molev',
    age: 33,
    school: 'EG',
    gpa: 5.0
};
// printStudentInfo(peshoPerson);     //!  Error  -  not FullStudent
printStudentInfo(solPerson);
// console.log(KeysOfPoint);         //!  Error  -  NOT possible in TS
let originPoint = {
    x: 0,
    y: 0
};
function changeCoordinate(point, coordinateName, newValue) {
    point[coordinateName] = newValue;
}
changeCoordinate(originPoint, 'x', 5);
console.log(originPoint);
let val;
val = { age: 33 }; //  let as input we do not know  A or B
if ('age' in val) { //  used as a Type Guard to narrow 'val' to a B
    console.log(val.age);
}
let pinPoint1 = { x: 12, y: 4 };
console.log(typeof pinPoint1); // object
let color1 = { red: 20 };
console.log(typeof pinPoint1 === typeof color1); // true since both are objects
const leftLeaf = {
    value: 5
};
const rightLeaf = {
    value: 10
};
const root = {
    value: 3,
    leftChild: leftLeaf,
    rightChild: rightLeaf
};
console.log(root);
let person1 = { name: 'Pesho', age: 20 };
let person2 = { name: 'Pesho', age: 20, isLucky: true };
function printPerson(person) {
    console.log(person.name);
}
printPerson(person1);
printPerson(person2);
//# sourceMappingURL=demo.js.map