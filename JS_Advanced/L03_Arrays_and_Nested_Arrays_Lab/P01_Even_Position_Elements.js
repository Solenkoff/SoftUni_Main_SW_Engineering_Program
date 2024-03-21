function evenPositionElements(arr){
    
    let result = [];

    for (let i = 0; i < arr.length; i += 2) {
        result.push(arr[i]);

    }

    return result.join(' ');

     // V_02

    // let result = '';

    // for (let i = 0; i < arr.length; i += 2) {
    //     result += arr[i] + ' ';
    // }

    // console.log(result);
}

console.log(evenPositionElements(['20', '30', '40', '50', '60']));


