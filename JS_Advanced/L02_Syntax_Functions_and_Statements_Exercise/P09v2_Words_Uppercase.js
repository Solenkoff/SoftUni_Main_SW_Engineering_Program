function wordsUppercase(input) {
    let regexPattern = /\w+/g; 

    let results = [...input.matchAll(regexPattern)]
        .map(x => x[0].toUpperCase())
        .join(', ');        

    console.log(results);
}

// function wordsUppercase(input) {
//     let regexPattern = /\w+/g;
//     let results = input.match(regexPattern);

//     console.log(
//         results
//             .map(x => x.toUpperCase())
//             .join(', '));
// }

wordsUppercase('Hi, how are you?');