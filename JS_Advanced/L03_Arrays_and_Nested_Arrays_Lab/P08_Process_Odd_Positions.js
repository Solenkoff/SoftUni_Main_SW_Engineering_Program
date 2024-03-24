function processOddPositions(arr){
    return arr.filter((num, numIndex) =>  numIndex % 2 !== 0)
              .map(num => num * 2)
              .reverse()
              .join(' ');

}

console.log(processOddPositions([10, 15, 20, 25]));
