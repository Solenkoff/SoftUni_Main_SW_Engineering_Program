interface Roaring {
    roar(): string;
    roar(otherName: string): string;
    roar(otherName: string, secondAnimal: string): string;
}

interface Friendly extends Roaring {
    sayHello(): void;
    name: string;
}

interface Aged {
    age: number;
}

abstract class Animal implements Roaring {
    private _name!: string;
    protected abstract age: number;

    constructor(name: string) {
        this.name = name;
    }

    get name() {
        return this._name;
    }

    set name(val: string) {
        if (val.length === 0) {
            throw new Error('Name cannot be empty!');
        }
        this._name = val;
    }

    abstract sayHello(): void;

    roar(): string;
    roar(otherName: string): string;
    roar(otherName: string, secondAnimal: string): string;
    roar(a?: string, b?: string) { 
        let original = `Animal ${this.name}`;
        let second =  a ? ` and ${a}` : '';
        let third = b ? ` and ${b}` : '';

        return `${original}${second}${third} roars!`;
    }
}

class Bear extends Animal implements Aged {
    protected readonly _age: number;

    constructor(name: string, age: number) {
        super(name);
        this._age = age;
    }

    get age() {
        return this._age;
    }

    sayHello(): void {
        console.log(`${this.name} age: ${this.age} says hello.`);

    }

    //roar() { return `${this._name} roars!` };
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


let c: Roaring = b; 
c.roar();
c.roar('Pesho');
c.roar('Pesho', 'Gosho');
//* c.roar('Pesho', 'Gosho', 'Invalid');   //*  Does not fir interface signatures



let d:Friendly = new Bear('Gana', 7);      //*   Polimorphism  Bear as Friendly(I)
console.log(d.name);
console.log(d.sayHello());
console.log(d.roar());
console.log(d.roar('Pesho'));
console.log(d.roar('Pesho', 'Gosho'));

