function theLargestNum(firstNum, secondNum, thirdNum){
    console.log(`The largest number is ${Math.max(firstNum, secondNum, thirdNum)}.`);

    // Using the "REDUCE" method => array.reduce()
    // let arrOfNums = [firstNum, secondNum, thirdNum];
    // const maxNum = arrOfNums.reduce((a,b) => Math.max(a, b), -Infinity);
    // console.log(`The largest number is ${maxNum}.`);
}

theLargestNum(-3, -5, -22.5);