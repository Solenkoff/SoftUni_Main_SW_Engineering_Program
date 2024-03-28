function increasingSubset(arr){
    let resultArr = [];

    arr.reduce((resultArr, b) => {
        if (resultArr.length == 0 || resultArr[resultArr.length - 1] <= b) {
            resultArr.push(b);
        }

        return resultArr;

    }, resultArr);

    return resultArr;
} 

console.log(increasingSubset([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(increasingSubset([1,  2,  3, 4]));
console.log(increasingSubset([20, 3, 2, 15,6, 1]));