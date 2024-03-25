function equalNeighbors(matrix){
    let equalNeighborCount = 0;

    function isValidPosition(matrix, row, col){
        let isValid = false;
    
        if(row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length){
            isValid = true;
        }
    
        return isValid;
    }

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
           if(isValidPosition(matrix, row - 1, col) && matrix[row - 1][col] === matrix[row][col]){
               equalNeighborCount++;
           }
           if(isValidPosition(matrix, row + 1, col) && matrix[row + 1][col] === matrix[row][col]){
               equalNeighborCount++;
           }
           if(isValidPosition(matrix, row, col - 1) && matrix[row][col - 1] === matrix[row][col]){
               equalNeighborCount++;
           }
           if(isValidPosition(matrix, row, col + 1) && matrix[row][col + 1] === matrix[row][col]){
               equalNeighborCount++;
           }
        }
    }

    const neighborPairs = equalNeighborCount / 2;
    return neighborPairs;
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