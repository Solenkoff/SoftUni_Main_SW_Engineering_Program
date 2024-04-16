function lowestPricesInCities(input){
    const products = {};

    for (const product of input) {
        const [town, productName, checkPrice] = product.split(' | ');

        if(!products[productName]){
            products[productName] = {
                price: checkPrice,
                townName: town
            }
        }
        if(product[productName] > checkPrice ){
            product[productName]['price'] = checkPrice;
            product[productName]['townName'] = town;
        }
    }
   
    Object.keys(products).forEach(key => 
        console.log(`${key} -> ${products[key].price} (${products[key].townName})`));
}


lowestPricesInCities(
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
    
  );


  