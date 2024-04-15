function carFactory(orderedCar){
    let assembeledCar = {};

    function createEngine(power){
        if(power > 120 ){
            return {power : 200, volume : 3500};
        }else if(power > 90){
            return {power : 120, volume : 2400};
        }else{
            return {power : 90, volume : 1800};
        }
    }

    let wheelSize = orderedCar.wheelsize % 2 == 0 ? 
        orderedCar.wheelsize - 1 : 
        orderedCar.wheelsize;

    assembeledCar.model = orderedCar.model;
    assembeledCar.engine = createEngine(orderedCar.power);
    assembeledCar.carriage = { 
        type : orderedCar.carriage , 
        color : orderedCar.color
    };  
    assembeledCar.wheels = new Array(4).fill(wheelSize);

    return assembeledCar;
}

console.log(carFactory({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));
console.log(carFactory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
));
