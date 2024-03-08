function theLargestNum(firstNum, secondNum, thirdNum){
    let largestNum = firstNum;

    if(secondNum > firstNum){
        largestNum = secondNum;
    }

    if(thirdNum > largestNum){
        largestNum = thirdNum;
    }

    console.log(`The largest number is ${largestNum}.`)
}

theLargestNum(-3, -5, -22.5);