function sortingNumbers(arr) {    
    arr.sort((a, b) => a - b);
    
    for (let index = 0; index < arr.length; index += 2) {
       const maxElement = arr.pop();

       arr.splice(index + 1, 0, maxElement);
    }

    return arr;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));