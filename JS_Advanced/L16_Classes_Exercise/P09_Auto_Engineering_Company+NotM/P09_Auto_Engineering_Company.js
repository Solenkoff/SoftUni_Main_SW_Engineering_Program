// ----  V_01  Git SilviyaIvanova91    -----

function autoEngineeringCompany(arr) {
    let carRegistry = {};

    arr.forEach((line) => {
        let [brand, model, qty] = line.split(" | ");

        if (!carRegistry.hasOwnProperty(brand)) {
            carRegistry[brand] = {};
        }

        if (!carRegistry[brand].hasOwnProperty(model)) {
            carRegistry[brand][model] = 0;
        }

        carRegistry[brand][model] += Number(qty);
    });

    for (const brand in carRegistry) {
        console.log(brand);
        Object.entries(carRegistry[brand]).forEach((el) =>
            console.log(`###${el[0]} -> ${el[1]}`)
        );
    }
}


// ----  V_02  Git Universe8888    -----

// function autoEngineeringCompany(input) {
//     const cars = input.reduce((acc, line) => {
//         let [brand, model, produced] = line.split(' | ');
//         produced = Number(produced);

//         if (!acc[brand]) {
//             acc[brand] = {};
//         }
//         if (!acc[brand][model]) {
//             acc[brand][model] = 0;
//         }
//         acc[brand][model] += produced;

//         return acc;
//     }, {});

//     return Object.entries(cars).map(([brand, models]) => {
//         const modelDetails = Object.entries(models)
//             .map(([model, count]) => `###${model} -> ${count}`)
//             .join('\n');
//         return `${brand}\n${modelDetails}`;
//     }).join('\n');
// }

console.log(autoEngineeringCompany([
    'VW | Golf-4 | 10000000',
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]));