function biggerHalf(input){ 
    const halfIndex = Math.floor(input.length / 2);

    let result =  input.sort((a,b) => a - b).slice(halfIndex);

    return result;
}

console.log(biggerHalf([4, 7, 2, 5]));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));
