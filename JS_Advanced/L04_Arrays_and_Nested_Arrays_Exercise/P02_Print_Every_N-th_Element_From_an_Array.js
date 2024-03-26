function PrintEveryNth(arr, step){
    // let selected = [];

    // for (let i = 0; i < arr.length; i += step) {
    //     selected.push(arr[i]);   
    // }

    // return selected;

    return arr.filter((x, i) => i % step == 0);
}

console.log(PrintEveryNth(['5', '20', '31', '4', '20'], 2));
console.log(PrintEveryNth(['dsa','asd', 'test', 'tset'], 2));
console.log(PrintEveryNth(['1', '2','3', '4', '5'], 6));


