function squareOfStars(n = 5) {
    let result = '';
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            result += '* ';
        }
        result += '\n';
    }
    console.log(result);
}
squareOfStars(1);
squareOfStars(2);
squareOfStars(5);
squareOfStars();