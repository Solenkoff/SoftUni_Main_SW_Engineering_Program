function increasingSubset(arr){
    let resultArr = [];

    resultArr.push(arr[0]);

    for (let i = 1; i < arr.length; i++) {

        if(arr[i] >= resultArr[resultArr.length-1]){
            resultArr.push(arr[i]);
        }  
    }

    return resultArr;
} 

console.log(increasingSubset([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(increasingSubset([1,  2,  3, 4]));
console.log(increasingSubset([20, 3, 2, 15,6, 1]));
