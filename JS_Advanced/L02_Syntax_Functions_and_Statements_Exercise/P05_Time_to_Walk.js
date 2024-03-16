function timeToWalk(steps, footLength, speedKmH){
    
    let distance = steps * footLength;
    let speedMpSec = speedKmH * 1000 / 3600;

    let time = distance / speedMpSec;
    let breaksTime = Math.floor(distance / 500) * 60;
    let totalTime = time + breaksTime;

    let hours = Math.floor(totalTime / 3600).toString().padStart(2, '0');
    let minutes = Math.floor(totalTime / 60).toFixed(0).padStart(2, '0');
    let seconds = (totalTime % 60).toFixed(0).padStart(2, '0');

    console.log(`${hours}:${minutes}:${seconds}`);

}

timeToWalk(2564, 0.70, 5.5);