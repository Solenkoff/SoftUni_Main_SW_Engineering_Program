function sortingNumbers(arr){
    arr.sort((a,b) => a - b);

    let length = arr.length;
    let sortedArr= [];
    

    for (let i = 0; i < length; i++) {
        if(i % 2 == 0){
            sortedArr.push(arr.shift());
        }else{
            sortedArr.push(arr.pop());
        }    
    }

    return sortedArr;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));