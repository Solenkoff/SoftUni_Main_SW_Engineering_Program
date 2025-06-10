

//*    Union Tupes   

function printGreeting(text: string | string[]): void {
    if (typeof text === 'string') {
        console.log(text);
    } else {
        console.log(text.join(' '));
    }
}

printGreeting('Hello Sol!');
printGreeting(['Hello', 'its', 'me!']);


//*   Intersection Types

//   Farther Down


//*   Literal Types

let passFailedGrade: 'pass' | 'fail';
passFailedGrade = 'pass';
passFailedGrade = 'fail';
// passFailedGrade = 'Excellent';    //!  Error
console.log(passFailedGrade);

let numericGrade: 2 | 3 | 4 | 5 | 6;
numericGrade = 3;
numericGrade = 6;
// numericGrade = 8;    //!  Error
console.log(numericGrade);


//*   Type Aliases  -  custom name for a type  Pascal Case

//   primitive
// type Id = number;
// function greet(humanId: Id) => console.log(humanId);

type Age = number;                      //*  primitive
type User = { age: Age };                //*  with type  Alias  (Age)
type PersonType = { name: string };     //*  object
type Combined = User & Person           //*  advanced type -> intersection type

type Person = {                         //*  Custom Type
    firstName: string;
    lastName: string;
    age: number;
}

type StudentProfile = {
    school: string;
    gpa?: number;
}

type FullStudent = Person & StudentProfile;    //*  Intersection Type 

function printStudentInfo(student: FullStudent) {
    if(student.gpa){
        console.log(`Student ${student.firstName} ${student.lastName}, GPA: ${student.gpa}`);
    } else {
        console.log(`Student ${student.firstName} ${student.lastName}`);    }
}

let peshoPerson: Person = {      // exact match of type Person
    firstName: 'Pesho',
    lastName: 'Ivanov',
    age: 17
};

let solPerson: FullStudent = {
    firstName: 'Sol',
    lastName: 'Molev',
    age: 33,
    school: 'EG',
    gpa: 5.0
}

// printStudentInfo(peshoPerson);     //!  Error  -  not FullStudent
printStudentInfo(solPerson);


//*   "keyof"

type Point = {
    x: number;
    y: number;
}

type KeysOfPoint = keyof Point;
// console.log(KeysOfPoint);         //!  Error  -  NOT possible in TS

let originPoint: Point = {
    x: 0,
    y: 0
}

function changeCoordinate(point: Point, coordinateName: keyof Point, newValue: number) {
    point[coordinateName] = newValue;
}

changeCoordinate(originPoint, 'x', 5);
console.log(originPoint);


//*   "in"   ->  as Type Guard or iterate ove "keyof" result

type A = { name: string };
type B = { age: number };

let val: A | B;
val = { age: 33 };              //  let as input we do not know  A or B

if ('age' in val) {             //  used as a Type Guard to narrow 'val' to a B
    console.log(val.age);
}


//*   "typeof"  ->  extract TS type information from variables

type PinPoint = { x: number; y: number; };
let pinPoint1: PinPoint = { x: 12, y: 4 };
console.log(typeof pinPoint1)                    // object

type pinPoint2 = typeof pinPoint1;               // { x: number; y: number; }

type Color = { red: number };
let color1 = { red: 20 };

console.log(typeof pinPoint1 === typeof color1)  // true since both are objects


//*   Mapped Types

type PointToMap = {
    x: number;
    y: number;
}

type PartialPoint = {
    [K in keyof PointToMap]?: PointToMap[K];
};

type Colors = { red: string; blue: string; };
type ReadonlyColort = {
    readonly [K in keyof Colors]: Colors[K];
};


//*   Recursive Types

type TreeNode = {
    value: number;
    leftChild?: TreeNode;
    rightChild?: TreeNode;
}

const leftLeaf: TreeNode = {
    value: 5
};

const rightLeaf: TreeNode = {
    value: 10
};

const root: TreeNode = {
    value: 3,
    leftChild: leftLeaf,
    rightChild: rightLeaf
}

console.log(root);
 

//  --------------------------------


//*    Specifics  -->  Strange Behaviour  /  Requirements for structure  
//*                =>  Can call an object as a type or class if it covers the signature(structure) even if it 
//*                    has additianal props or methods, which would not be available if called as that type or class

type PersonOne = {
    name: string,
    age: number
};

let person1: PersonOne = { name: 'Pesho', age: 20 };
let person2 = { name: 'Pesho', age: 20, isLucky: true };          //*  Without the type NO WORNING just simple JS object
// let person2: PersonOne = { name: 'Pesho', age: 20, isLucky: true };   //!   It covers the signature BUT additional properties give WORNING

function printPerson( person: PersonOne){
    console.log(person.name);                   //*  Can call them all BUT person. can take only the props asigned in
                                                //*  the signiture ( name & age ) and not the addiional ones ( isLucky )
}

printPerson(person1);
printPerson(person2);    //!  Worning but lets you run it in the function -> JS



//   Extra  -->  Examples and Specifics


let test = { name: 'Pesho', age: 20 };

console.log(test.name);

type a = typeof test;
type b = keyof typeof test;
type c = {
    [K in keyof typeof test]: typeof test[K]
}
 

//  -----------------


type test1 = { name: string, age: number};

function returnTest1(): test1 {
    let a = { name: 'Pesho', age: 20, lucky: true };             //*  1 -> Not specifically typed as test1 just
                                                                 //*       covers the signature
//  let a: test1 = { name: 'Pesho', age: 20, lucky: true };      //*  2 -> Specifically typed as test1
    return a;
}

let b = returnTest1();

console.log(b);           //*  ->    1   =>   {name: 'Pesho', age: 20}
                          //*  ->    2   =>   {name: 'Pesho', age: 20, lucky: true}   with WORNING