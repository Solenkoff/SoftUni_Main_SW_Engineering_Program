function cumulativeSumOfcurrSums(n, k){
    let array = [1];
    let currSum = 0;

    for (let i = array.length; i < n; i++) {        
       currSum = array.slice(-k).reduce((a, v) => a + v, 0);
       array.push(currSum);
    }
    return array;
};


console.log(cumulativeSumOfcurrSums(6, 3));
console.log(cumulativeSumOfcurrSums(8, 2));

