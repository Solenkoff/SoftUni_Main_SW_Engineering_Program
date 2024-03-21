function sumFirstLast(arr){
    let sum = 0;

    let firstNum = parseInt(arr.shift());
    let lasttNum = parseInt(arr.pop());

    sum = firstNum + lasttNum;

    return sum;

}

console.log(sumFirstLast(['20', '30', '40']));
