function orbit(inputArr){
    const [cols, rows, x, y] = inputArr;

    let matrix = new Array(rows); 

    for (let row = 0; row < rows; row++) {

        matrix[row] = new Array(cols);

        for (let col = 0; col < cols; col++) {

            const rowVariance = Math.abs(row - x);
            const colVariance = Math.abs(col - y);

            matrix[row][col] = Math.max(rowVariance, colVariance) + 1;            
        }        
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

orbit([4, 4, 0, 0]);

orbit([5, 5, 2, 2]);

orbit([3, 3, 2, 2]);