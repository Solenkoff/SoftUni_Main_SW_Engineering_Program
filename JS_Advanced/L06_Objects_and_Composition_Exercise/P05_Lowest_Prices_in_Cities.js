function lowestPricesInCities(inputArr){
    let products = {};

    inputArr.forEach(element => {
        const [productTown, productName, productPrice] = element.split(' | ');

        if (!products.hasOwnProperty(productName)) {
            products[productName] = {};            
        }
        
        products[productName][productTown] = Number(productPrice);
    });
    
    for (const productName in products) {
       const sortedByName = Object.keys(products[productName])
                                  .sort((a, b) => products[productName][a] - products[productName][b]);

       console.log(`${productName} -> ${products[productName][sortedByName[0]]} (${sortedByName[0]})`);
    }
    
}

lowestPricesInCities(
    [
        'Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10'
    ]
);
