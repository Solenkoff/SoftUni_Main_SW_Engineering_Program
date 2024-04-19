function townsToJSON(inputArr){
    let towns = [];

    function inputSplit(input){
        return input.split('|').slice(1).map(x => x.trim());
    }

    const [town, latitude, longtitude] = inputSplit(inputArr.shift());

    inputArr.forEach(element => {
        const [townName, townLatitude, townLongtitude] = inputSplit(element);
        towns.push({
            [town] : townName,
            [latitude] : Number(Number(townLatitude).toFixed(2)),
            [longtitude] : Number(Number(townLongtitude).toFixed(2)),
        })
    });

    return JSON.stringify(towns);
}

console.log(townsToJSON(
    [
        '| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |'
    ]
));

console.log(townsToJSON(
    [
        '| Town | Latitude | Longitude |',
        '| Veliko Turnovo | 43.0757 | 25.6172 |',
        '| Monatevideo | 34.50 | 56.11 |'
    ]
));