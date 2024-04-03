function magicMatrices(arr){
    let isMagic = true;

    const rowSum = arr[0].reduce((a,b) => a + b, 0);

    for (let i = 0; i < arr.length; i++) {
        let colSum = 0;
        for (let j = 0; j < arr.length; j++) {
           colSum += arr[j][i];       
        }
        if(arr[i].reduce((a,b) => a + b, 0) !== rowSum || colSum !== rowSum){
            isMagic = false;
        }       
    } 
    
    return isMagic;
}


console.log(magicMatrices([
    [4, 5, 6], 
    [6, 5, 4], 
    [5, 5, 5]]));
console.log(magicMatrices([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]));
 console.log(magicMatrices([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]));