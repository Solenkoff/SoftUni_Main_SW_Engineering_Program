function jansNotation(inputArr){

    const operands = []; 

    const operation = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
    };

    for (const element of inputArr) {
        if (Number.isInteger(element)) {
            operands.push(element);
            continue;
        }

        if (operands.length < 2) {
            console.log('Error: not enough operands!');
            return;
        }

        let lastNum = operands.pop();
        let secondLastNum = operands.pop();
                
        operands.push(operation[element](secondLastNum, lastNum));
    }

    if(operands.length === 1){
        console.log(operands[0]); 
    }else{
        console.log('Error: too many operands!');
        return;
    }

}

jansNotation([3, 4, '+']);
jansNotation([5, 3, 4, '*', '-']);
jansNotation([7, 33, 8, '-']);

