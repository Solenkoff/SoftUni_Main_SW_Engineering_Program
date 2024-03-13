function greatestCDivisor(a, b){
    let num1 = Math.abs(a);
    let num2 = Math.abs(b);

    while(num1 !== num2){
        if(num1 > num2){
            num1 -= num2;
        }else if(num2 > num1){
            num2 -= num1;
        }
    }

    console.log(num1);
}

greatestCDivisor(12, 20);