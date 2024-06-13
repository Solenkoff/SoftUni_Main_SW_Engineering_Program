function solve() {
    let types = {};
    for (let arg of arguments) {
        console.log(`${typeof arg}: ${arg}`);
        !types[typeof arg] ? types[typeof arg] = 1 : types[typeof arg]++;
    }

    Object.keys(types).sort((a, b) => types[b] - types[a]).forEach(x => console.log(`${x} = ${types[x]}`));
}

//----  Variant 2  Mine  ----------

// function solve(...inputParts) {

//     //const inputParts = arguments;

//     const typeCounts = {};

//     for (const part of inputParts) {
//         const type = typeof (part);
//         console.log(`${type}: ${part}`);
//         if (!typeCounts[type]) {
//             typeCounts[type] = 0;
//         }

//         typeCounts[type]++;
//     }

//     for (const type in typeCounts) {
//         console.log(`${type} = ${typeCounts[type]}`);
//     }
// }

//------------------------------------


solve('cat', 42, function () { console.log('Hello world!'); });