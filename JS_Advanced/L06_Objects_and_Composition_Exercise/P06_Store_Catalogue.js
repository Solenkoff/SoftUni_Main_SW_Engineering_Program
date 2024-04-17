function storeCatalogue(inputArr){
    let sortedInput = inputArr.sort((a,b) => a.localeCompare(b));

    let catalogue = {};

    for (const element of sortedInput) {
        const [productName, price] = element.split(' : ');
        const firstLetter = productName[0];

        if(!catalogue.hasOwnProperty(firstLetter)){
            catalogue[firstLetter] = {};
        }

        catalogue[firstLetter][productName] = Number(price);
    }

    for (const letter in catalogue) {
        const sortedPruducts = Object.keys(catalogue[letter]).sort((a,b) => a.localeCompare(b));

        console.log(letter);
        sortedPruducts.forEach(productName => 
            console.log(`  ${productName}: ${catalogue[letter][productName]}`));
        
    }
}

storeCatalogue([
'Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10'
]);
storeCatalogue([
'Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10'
]);