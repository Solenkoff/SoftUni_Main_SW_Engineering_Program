function equalNeighbors(matrix) {
    let equalNeighborCount = 0;

    let isValidPosition = (row, col) => row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {

            if (isValidPosition(row, col + 1)) {
                if (matrix[row][col + 1] === matrix[row][col]) {
                    equalNeighborCount++;
                }
            }
            if (isValidPosition(row + 1, col)) {
                if (matrix[row + 1][col] === matrix[row][col]) {
                    equalNeighborCount++;
                }
            } 
        }
    }

    return equalNeighborCount;
}

console.log(equalNeighbors([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
    ));
    
    console.log(equalNeighbors([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
    ));