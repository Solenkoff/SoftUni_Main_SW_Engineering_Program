
//*    ---  Mapped types using generics  ---

type User = {
    id: number;
    username: string;
    email: string;
};

type Point = {
    x: number;
    y: number;
};


type MakeOptionalProperty<T> = {
    [K in keyof T]?: T[K]
}


type PartialUser = MakeOptionalProperty<User>;
type PartialPoint = MakeOptionalProperty<Point>;



//*    ---  Index Access Types  ---

type Person = { name: string, age: number, isLocal: boolean};

type Age = Person['age'];                    //*  =>  number
type All = Person[keyof Person];             //*  =>  string | number | boolean
type local = Person['name' | 'isLocal'];     //*  =>  string | boolean
type temp = 'age' | 'isLocal';
type census = Person[temp];                  //*  =>  number | boolean
// type test = Person['test']                //*  =>  Error: 'test' not in Person



//*    ---  Conditional Types  ---

type Employee = {
    name: string;
    age: number;
    salary: number; 
}

type Product = {
    title: string;
    price: number;
    inStock: boolean;
    rating: number;
};

// type GetNumericKeys<T> = {                                //* with given type (number)
//     [K in keyof T]: ( T[K] extends number ? K : never )
// }[ keyof T]

type GetNumericKeys<T, U> = {
    [K in keyof T]: ( T[K] extends U ? K : never )           //* with generic type ( U )
}[ keyof T]


// name: never
// age: 'age'
// salary: 'salary'

type EmployeeNumeriKeys = GetNumericKeys<Employee, number>;
type ProductNumericKeys = GetNumericKeys<Product, boolean>;