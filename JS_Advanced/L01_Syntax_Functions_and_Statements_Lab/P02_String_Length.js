function totLength(first, second, third){
    let lengthSum = first.length + second.length + third.length;
    let avgLength = Math.floor(lengthSum / 3);

    console.log(lengthSum);
    console.log(avgLength)
}

totLength('pasta', '5', '22.3');