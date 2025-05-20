interface Animal{
    name: string;
    age: number;
    // makeSound: (soundName: string) => void;
    makeSound(soundName: string): void;
}   


//*   Implementing Class

class Dog implements Animal{
    public name: string;
    public age: number;
    
    constructor(n: string, a:number){
        this.name = n;
        this.age = a;
    }

    makeSound(soundName: string): void {
        console.log(soundName);
    }
}

const doggie = new Dog('Pesho', 2);
doggie.makeSound('Dzhaf-dzhaf!');


//*    Type  vs.  Interface

//    Type
type Person = {
    firstName: string;
    lastName: string;
    age: number;
}

type StudentProfile = {
    school: string;
    gpa: number;
}

type FullStudent = Person & StudentProfile;     //*  Intersection Type

//?   Use Type when: -  New Name for primitive types 
//?                  -  Defining  union / tuple / other complex types
 

//    Interface
interface PersonI {
    firstName: string;
    lastName: string;
    age: number;
}

interface StudentProfileI extends PersonI {    //*  Extending other Interface 
    school: string;
    gpa: number;
}

//?   Use Interface when: -  Defining object structure
//? 