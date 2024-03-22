function negativePositiveNumbers(arrOfNums) { 
    const resultArray = [];

    arrOfNums.forEach(x => x < 0 ? resultArray.unshift(x) : resultArray.push(x));  
      
    resultArray.forEach(x => console.log(x));
}

negativePositiveNumbers([7, -2, 8, 9]);
negativePositiveNumbers([3, -2, 0, -1]);