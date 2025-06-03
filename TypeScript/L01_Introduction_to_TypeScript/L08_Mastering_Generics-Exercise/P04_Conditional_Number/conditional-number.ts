type InputParamType<T> = T extends number ? number : string;


function conditionalNumber<T>(param: InputParamType<T>): void{

    if( typeof param === 'number'){
        console.log(param.toFixed(2));
    } else {
        console.log(param);
    }
}

conditionalNumber<number>(20.3555);
conditionalNumber<string>('wow');
conditionalNumber<boolean>('a string');

//conditionalNumber<boolean>(30);        //TS error: type 'number' is not assignable to parameter of type 'string'
//conditionalNumber<number>('test');     //TS error: type 'string' is not assignable to parameter of type 'number'
