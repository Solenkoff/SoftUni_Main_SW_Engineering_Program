"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Animal {
    _name;
    constructor(name) {
        this.name = name;
    }
    get name() {
        return this._name;
    }
    set name(val) {
        if (val.length === 0) {
            throw new Error('Name cannot be empty!');
        }
        this._name = val;
    }
    roar(a, b) {
        let original = `Animal ${this.name}`;
        let second = a ? ` and ${a}` : '';
        let third = b ? ` and ${b}` : '';
        return `${original}${second}${third} roars!`;
    }
}
class Bear extends Animal {
    _age;
    constructor(name, age) {
        super(name);
        this._age = age;
    }
    get age() {
        return this._age;
    }
    sayHello() {
        console.log(`${this._name} age: ${this.age} says hello.`);
    }
}
// let a = new Animal('Martha');
let b = new Bear('Martha', 8);
// console.log(b.roar());
// b.sayHello();
// let x: number | undefined;
// x! * 2;
console.log(b.roar());
console.log(b.roar('Pesho'));
console.log(b.roar('Pesho', 'Gosho'));
//# sourceMappingURL=example.js.map