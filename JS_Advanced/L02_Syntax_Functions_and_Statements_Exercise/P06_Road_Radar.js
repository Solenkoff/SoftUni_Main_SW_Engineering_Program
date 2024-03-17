function roadRadar(speed, area){

    let speedLimit;

    switch (area) {
        case 'motorway': speedLimit = 130; break;
        case 'interstate': speedLimit = 90; break;
        case 'city': speedLimit = 50; break;
        case 'residential': speedLimit = 20; break;
    }

    if(speed <= speedLimit){
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }else{
        let status = 'speeding';
        let speedOverTheLimit = speed - speedLimit;
      
        if(speedOverTheLimit > 40){
            status = 'reckless driving';
        }else if(speedOverTheLimit > 20){
            status = 'excessive speeding';
        }
        
        console.log(`The speed is ${speedOverTheLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
    
}

roadRadar(200, 'motorway');

