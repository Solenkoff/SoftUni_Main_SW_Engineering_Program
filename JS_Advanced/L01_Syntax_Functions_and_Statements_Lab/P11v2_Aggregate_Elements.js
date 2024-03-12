function aggregateElements(arr){
    let sumOfElements = arr.reduce((a, b) => a + b, 0);
    let sumOfReverseElements = arr.reduce((a, b) => a + 1/b, 0);
    let concatElements = arr.join('');

    console.log(sumOfElements);
    console.log(sumOfReverseElements);
    console.log(concatElements);
}

aggregateElements([1, 2, 3]);
