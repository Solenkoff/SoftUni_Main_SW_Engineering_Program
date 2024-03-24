function pieceOfPie(arr, flavor1, flavor2){
    const index1 = arr.indexOf(flavor1);
    const index2 = arr.indexOf(flavor2);

    const result = arr.slice(index1, index2 + 1); 

    return result;
}


console.log(pieceOfPie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));