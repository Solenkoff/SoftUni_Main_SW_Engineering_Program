function gcd(a, b){
    
    while (b != 0) {
        const temp = b;
        b = a % b;
        a = temp;
    }

    //console.log(a);
    return a;
}

console.log(gcd(5, 15));
//console.log(gcd(2154, 458));
