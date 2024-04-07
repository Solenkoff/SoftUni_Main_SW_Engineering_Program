function cityRecord(name, population, treasury){
    const city = {};
    
    city.name = name;
    city.population = population;
    city.treasury = treasury;

    return city;

    // v.2
    // return {name, population, treasury};
}

console.log(cityRecord('Tortuga',
7000,
15000
));


