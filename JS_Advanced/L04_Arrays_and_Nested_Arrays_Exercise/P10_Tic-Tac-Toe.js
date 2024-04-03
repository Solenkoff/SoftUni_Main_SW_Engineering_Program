function ticTacToe(arr) {
    const matrix = new Array(3).fill().map(() => Array(3).fill(false));
        
    let player = 'X'

    for (const coordinates of arr) {
        const [row, col] = coordinates.split(' ').map(Number);

        if (matrix[row][col]) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        matrix[row][col] = player; 

        if (isWinner()) {
            console.log(`Player ${player} wins!`);
            break;
        }

        if (matrix.every(row => row.every(x => x))) {
            console.log('The game ended! Nobody wins :(');
            break;
        }

        player = player === 'X' ? 'O' : 'X';  
        
        function isWinner(){
            const isWinningRow = matrix[row].every(x => x === player);

            const currColumn = matrix.map(row => row[col]);
            const isWinningCol = currColumn.every(x => x === player);
          
            const primeryDiagonal = matrix.map((row, i) => row[i]); 
            const isWinningPrDiagonal = primeryDiagonal.every(x => x === player);
    
            const secondaryDiagonal = matrix.map((row, i) => row[row.length - 1 - i]);
            const isWinningSecDiagonal = secondaryDiagonal.every(x => x === player);

            return isWinningRow || isWinningCol || isWinningPrDiagonal || isWinningSecDiagonal;
        }
      
    }    

    matrix.forEach(row => console.log(row.join('\t')));
}

ticTacToe([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"
]);


ticTacToe([
    "0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"
]);

ticTacToe([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"
]);