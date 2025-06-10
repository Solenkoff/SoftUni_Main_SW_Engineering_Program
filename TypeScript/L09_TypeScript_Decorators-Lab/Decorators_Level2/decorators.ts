//*   ---  Class Decorators  ---

function FreezeClass(constructor: Function) {
    Object.freeze(constructor);
    Object.freeze(constructor.prototype);
}


//*   ---  Accessor Decorators  ---

function ValidateStringAccessor(target: any, propertyName: string, descriptor: PropertyDescriptor) {
    const originalSetter = descriptor.set;

    descriptor.set = function (val: string) {
        if (val.length < 3) {
            throw new Error('Length must be minimum 3 characters!');
        }

        return originalSetter?.call(this, val);
    }
 
    return descriptor;
}


//*   ---  Method Decorators  ---

function DepricatedMethod(target: any, methodName: string, descriptor: PropertyDescriptor){
    const originalMethod = descriptor.value;

    descriptor.value = function(...args: any[]){
        console.log(`Caution! Method ${methodName} is depricated! Consider using another one.`);;
        return originalMethod.apply(this, args);
    }

    return descriptor;
} 


//*   ---  Decorators with Factory  ---

function DepricatedMethodWithFactory(message: string) {
    return function (target: any, methodName: string, descriptor: PropertyDescriptor) {
        const originalMethod = descriptor.value;

        descriptor.value = function (...args: any[]) {
            console.log(`Caution! ${message}!`);
            return originalMethod.apply(this, args);
        }

        return descriptor;
    }

}



@FreezeClass
class User {

    name: string;
    age: number;

    private _email!: string;

    constructor(name: string, age: number, email: string) {
        this.name = name;
        this.age = age;
        this.email = email;
    }

    @ValidateStringAccessor
    get email() {
        return this._email;
    }

    set email(val: string) {
        this._email = val;
    }

    @DepricatedMethodWithFactory('Depricated method')
    @DepricatedMethod
    getInfo(condensed: boolean): string {
        return condensed ? `Person ${this.name}` : `Person ${this.name} is ${this.age} years old with email: ${this.email}`;
    }

}



const user1 = new User('Pesho', 12, 'pesho@yahoo.com');
const user2 = new User('Tosho', 24, 'tosho@yahoo.com');

user1.email = 'new@yahoo.com';

//console.log(user1.email);

// console.log(Object.isFrozen(User));
// console.log(Object.isFrozen(User.prototype));

console.log(user1.getInfo(false));


