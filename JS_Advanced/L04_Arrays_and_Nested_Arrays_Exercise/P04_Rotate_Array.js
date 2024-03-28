function rotateArray(arr, rotations){
    const moves = rotations > arr.length
        ? (rotations % arr.length)
        : rotations;
    
    for (let i = 0; i < moves; i++) {
        arr.unshift(arr.pop());
    }

    console.log(arr.join(' '));
}

//rotateArray(['1', '2', '3', '4'], 7);
rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 150000000);
