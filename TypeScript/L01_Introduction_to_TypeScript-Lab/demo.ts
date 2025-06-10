
// --------  Basic Data Types  -------

let firstName: string = 'Pesho';                                 //*  string
let lastName: string = 'Ivanov';                                 //*  string
let age: number = 30;                                            //*  number
let hasGradusted: boolean = false;                               //*  boolean
let uniqueSymbol: symbol = Symbol('mySymbol');                   //*  symbol
let undifinedValue1;                                             //*  undifined
let undifinedValue2: undefined = undefined;                      //*  undefined
let person: null = null;                                         //*  null
let skills: string[] = ['JS', 'HTML', 'Coming soon: TS'];        //*  array
let nums: number[] = [ 1, 2, 3, 4, 5 ];                          //*  array
let bools: boolean[] = [ false, true, true, false, true ];       //*  array

//  Tuple  ->  Array with fixed number of elements with exact types
let certificateInfo: [string, number, boolean] = [               //*  tuple
    'MySQL', 2025, true
]

enum Directions {                                                //*  enum
    Up,
    Down,
    Left,
    Right
}

function movePoint(point: { x: number, y: number }, moveDirection: Directions) {

    if (moveDirection === Directions.Up) {
        return { x: point.x, y: point.y + 1 };
    } else if (moveDirection === Directions.Down) {
        return { x: point.x, y: point.y - 1 };
    } else if (moveDirection === Directions.Left) {
        return { x: point.x - 1, y: point.y };
    } else if (moveDirection === Directions.Right) {
        return { x: point.x + 1, y: point.y };
    }

}

let point = { x: 0, y: 0 };
//console.log(movePoint(point, Directions.Right));

//*  Any , Unknown, Void   -->>  


// -------------

let strNumArr: (string | number)[] = ['Ivan', 45];


//*   ---------  Optional Data Types  -----------


function greetUser(username: string, addHello?: boolean): string {         //*  ?  ->  optional
    console.log(addHello);

    if (addHello) {
        return `Hello, ${username}`;
    }

    return username;
}


console.log(greetUser('Ivan', false));


//*   ---------  Type Assertion  ---------    

let val: unknown = 20;
let str = val as string;   //  as
let str2 = <string>val;    //  <> 

// const inputEl = document.getElementById('email') as HTMLInputElement;

// console.log(inputEl!.value);


//*   ---------  Type Guard  ---------


function formatDate(a: string | number, b: string | number) {

    if(typeof a === 'number' && typeof b === 'number'){
        console.log(a + b);
    } else {
        console.log(`${a}<->${b}`);
    }
}

formatDate( 5 , 'ivan');


//   --------  Type Guard  with  Type Predicate function (TPF)  ----------


function isNumber(val: string | number): val is number {            //  val is number -> Type narrowing
    return typeof val === 'number';
}

function formatDateWithTPF(a: string | number, b: string | number) {

    if(isNumber(a) && isNumber(b)){
        console.log(a + b);
    } else {
        console.log(`${a}<->${b}`);
    }
}

formatDateWithTPF( 5 , 'ivan');
