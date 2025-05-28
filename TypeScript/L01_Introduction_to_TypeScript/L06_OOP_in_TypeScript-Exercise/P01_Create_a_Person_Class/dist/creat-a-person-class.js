"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Person {
    firstName;
    lastName;
    age;
    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
    introduce() {
        return `My name is ${this.firstName} ${this.lastName} and I am ${this.age} years old.`;
    }
}
const person = new Person("John", "Doe", 30);
console.log(person.introduce());
//# sourceMappingURL=creat-a-person-class.js.map