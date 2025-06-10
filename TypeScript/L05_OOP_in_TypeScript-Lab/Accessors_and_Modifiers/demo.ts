type test = {
    name: string,
    ageInfo: {
        age: number
    }
}

type test2 = {
    name: 'Pesho' | 'Gosho';
    ageInfo: {
        age: number
    }
}

let person: test = {
    name: 'Ivan',
    ageInfo: {
        age: 20
    }
}

// let person: test2 = {
//     name: 'Ivan',
//     ageInfo: {
//         age: 20
//     }
// }



//*  Method Overriding

class Shape {
    draw() { return 'Drawing dhape'}
}

class Circle extends Shape {
    draw() { return `${super.draw()} + Drawing circle`}     //  Implicit ovreriding
}

let shape = new Shape();
let circle = new Circle();

console.log(shape.draw);
console.log(circle.draw);


//*  Method Overloading

class Person {
    greet(num: number): void;
    greet(fName: string, lName: string): void;
    greet(a: number | string, b?: string){
        console.log(typeof a == 'string'
            ? `${a} ${b}`
            : `Number: ${a}`);
    }
}

let person1 = new Person();
person1.greet(13);
person1.greet('John', 'Doe');
// person1.greet('John');           //* Works only Without overloading


//*  function something(...arr:any[]){       //     Most PERMISSIVE signature   !!!
//* 
//*  }


//*   Accessors      Getter / Setter

class President {
    _name!: string;               //*  ! ->  Definite Assignment Assertion  =>  Garantees prop/variable assignment

    constructor(name: string){
//        this._name = name;      //*  through prop(Field)                     NO VALIDATION
        this.name = name;         //*  through Setter  +  !  for the Warning   YES VALIDATION (in setter)
    }

    get name(){
        return this._name;
    }

    set name(val: string){
        this._name = val;
    }

}


//*  Access Modifiers

class Animal {
    public age: number;
    protected _name: string;
    private _weight: number;

    constructor(age: number, name: string, weight: number){
        this._name = name;
        this._weight = weight;
        this.age = age;
    }

    roar(){ return `Animal ${this._name} roars`};
}

class Bear extends Animal {
    roar() { return `${this._name} roars`};
}

let bear = new Bear(13, 'Martha', 165);
console.log(bear.age);                   //*    age IS accessible as is PUBLIC
//* console.log(bear._name);             //*  _name NOT accessible as is PROTECTED
//* console.log(bear._weight);           //*  _name NOT accessible as is PRIVATE
