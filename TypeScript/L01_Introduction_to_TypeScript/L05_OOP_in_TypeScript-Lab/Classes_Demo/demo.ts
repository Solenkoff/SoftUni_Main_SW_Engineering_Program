
//*  Access Modifiers

class Animal {
    public age: number;
    protected _name: string;
    private _weight: number;

    constructor(age: number, name: string, weight: number) {
        this._name = name;
        this._weight = weight;
        this.age = age;
    }

    roar() { return `Animal ${this._name} roars` };
}

class Bear extends Animal {
    roar() { return `${this._name} roars` };
}

let bear = new Bear(13, 'Martha', 165);
console.log(bear.age);                   //*    age IS accessible as is PUBLIC
//* console.log(bear._name);             //*  _name NOT accessible as is PROTECTED
//* console.log(bear._weight);           //*  _name NOT accessible as is PRIVATE


//*   Static

class Manufacturing {
    public maker: string;
    public model: string;
    public static vehiclesCount = 0;                     //*  NOT accessible outside the class

    constructor(maker: string, model: string,) {
        this.maker = maker;
        this.model = model;
    }
    createVehicle() {
        let calls = ++Manufacturing.vehiclesCount;       //*  called only referencing the class itself 
        return `createVehicle called: ${calls} times`;
    }
}


//*   Abstract

abstract class Department {
    public depName: string;
    constructor(n: string) { this.depName = n; }
    abstract sayHello(): void;
}

class Engineering extends Department {
    constructor(depName: string, public employee: string) {
        super(depName);
    }

    sayHello() {                                                          //*  MUST have it as abstract in parent
        return `${this.employee} of ${this.depName} department says hi!`;
    }
}

//* let dep = new Department('Test')     // Cannot create instance of abstract class


//*   Readonly

class Employee {
    readonly name: string;
    constructor(n: string) {
        this.name = n;
    }
}

let employee = new Employee('Martha');
//* employee.name = 'Thomas';            //Error: name is read-only.