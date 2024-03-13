function fruits(fruit, weight, price){
    let fruitType = fruit;
    let weightInGr = weight;
    let pricePerKg = price;

    let weightInKg = weightInGr / 1000;
    let moneyNeeded = weightInKg * pricePerKg;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruitType}.`);
}

fruits('apple', 1563, 2.35)