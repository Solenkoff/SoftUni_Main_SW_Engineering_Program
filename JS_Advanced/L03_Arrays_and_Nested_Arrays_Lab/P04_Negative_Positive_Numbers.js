function negativePositiveNumbers(arr){
    let sortedArr = [];

    for (let i = 0; i < arr.length; i++) {

        let currNum = parseInt(arr[i]);

        if(currNum < 0){
            sortedArr.unshift(currNum);
        }else{
            sortedArr.push(currNum);
        }
    }

    sortedArr.forEach(num => {
        console.log(num);
    });
}

negativePositiveNumbers([7, -2, 8, 9]);
negativePositiveNumbers([3, -2, 0, -1]);
