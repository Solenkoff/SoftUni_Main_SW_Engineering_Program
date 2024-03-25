function diagonalSums(matrix){
    let diagonalA = 0;
    let diagonalB = 0;

    for (let i = 0; i < matrix.length; i++) {
        diagonalA += Number(matrix[i][i]);
        diagonalB += Number(matrix[i][matrix.length - 1 - i]);
    }

    //console.log(`${diagonalA} ${diagonalB}`);
    console.log(diagonalA, diagonalB);

}

diagonalSums([
    [20, 40],
    [10, 60]]
   );

diagonalSums([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
);