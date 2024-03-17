function cookingByNumbers(inputNum, ...commands){
  
    let num = Number(inputNum);

    for (let i = 0; i < commands.length; i++) {
        let command = commands[i];
        
        switch (command) {
            case 'chop': num /= 2; break;
            case 'dice': num = Math.sqrt(num); break;

            case 'spice': num += 1; break;

            case 'bake': num *= 3; break;
            case 'fillet': num -= num * 0.2; break;
        }

        console.log(num);
    }
}

cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');