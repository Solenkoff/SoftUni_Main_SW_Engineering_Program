function timeToWalk(steps, footLength, speedKmH) {

    let distance = steps * footLength;
    let timeInSec = Math.round(distance / speedKmH * 3.6);
    let breaksTime = Math.floor(distance / 500) * 60;
    timeInSec += breaksTime;

    let result = new Date(timeInSec * 1000).toISOString().substr(11, 8)
    console.log(result);
}

timeToWalk(4000, 0.60, 5);