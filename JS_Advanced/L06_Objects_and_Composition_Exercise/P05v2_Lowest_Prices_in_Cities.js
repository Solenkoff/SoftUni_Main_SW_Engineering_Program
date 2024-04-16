function lowestPricesInCities(inputArr){
    let products = [];

    for (const element of inputArr) {
        let [townName, productName, price] = element.split(' | ');

        if(!products.some(x => x.productName === productName)){
            products.push(Object.assign({}, {
                townName, 
                productName, 
                price: Number(price)}));
        }

        let existingProduct = products.find(x => x.productName === productName);

        if(price < existingProduct.price){
            existingProduct.townName = townName;
            existingProduct.price = price;
        }       
    }

    for (const product of products) {
        console.log(`${product.productName} -> ${product.price} (${product.townName})`);       
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