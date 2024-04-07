function townPopulation(inputArr){
    const populationRegistry = {};

    for (const data of inputArr){
    
        const [townName, population] = data.split(' <-> ');

        if(!populationRegistry[townName]){
            populationRegistry[townName] = 0;
        }

        populationRegistry[townName] += Number(population);
    }

    for (const townName in populationRegistry) {
        console.log(`${townName} : ${populationRegistry[townName]}`);
    }  

    // Object.keys(populationRegistry)
    //     .forEach(townName => console.log(`${townName} : ${populationRegistry[townName]}`));
    
}

console.log(townPopulation([
'Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
));
console.log(townPopulation([
'Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
));