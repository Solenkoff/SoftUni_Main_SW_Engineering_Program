function mathOperations(firstNum, secondNum, operator){
    let result;

    if(operator == '+'){
        result = firstNum + secondNum;
    }else if(operator == '-'){
        result = firstNum - secondNum;
    }else if(operator == '*'){
        result = firstNum * secondNum;
    }else if(operator == '/'){
        result = firstNum / secondNum;
    }else if(operator == '%'){
        result = firstNum % secondNum;
    }else if(operator == '**'){
        result = firstNum ** secondNum;
    }

    console.log(result);
}

mathOperations(3, 5.5, '*');