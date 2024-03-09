function circleArea(input){

    let inputType = typeof(input);
    let result = '';

    if(inputType == 'number'){
        let area = Math.PI * Math.pow(input, 2);
        result = area.toFixed(2);    
    }else {
        result = `We can not calculate the circle area, because we receive a ${inputType}.`;
    }

    console.log(result);

}

circleArea(5);