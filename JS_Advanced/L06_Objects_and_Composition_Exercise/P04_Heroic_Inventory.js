function heroicInventory(inputArr){
    let heroesRegister = [];

    inputArr.forEach(element => {
        const [heroName, heroLevel, heroItems] = element.split(' / ');
        const hero = {
            name : heroName, 
            level : Number(heroLevel), 
            items : heroItems ? heroItems.split(', ') : [],
        };

        heroesRegister.push(hero);
    });

    return JSON.stringify(heroesRegister);
}

console.log(heroicInventory(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log(heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']));
