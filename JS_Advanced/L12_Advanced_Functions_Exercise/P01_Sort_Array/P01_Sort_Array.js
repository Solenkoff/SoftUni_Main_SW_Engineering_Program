function solve(arr, command) {
    if (command == "asc") {
        arr.sort((a, b) => a - b);
    } else {
        arr.sort((a, b) => b - a);
    }
    return arr;
}

//  ----  Variant 2  --------

// function solveOne(arr, command){

//     const sortingFuncs = {
//         asc: (a, b) => a - b,
//         desc: (a, b) => b - a
//     }

//     return arr.sort(sortingFuncs[command]);
// }

//------------------------------

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solveOne([14, 7, 17, 6, 8], 'asc'));
