function calorieObject(inputArr){
     const result = {};

     for (let i = 0; i < inputArr.length ; i += 2) {
             result[inputArr[i]] = Number(inputArr[i + 1]);
     }

    return result;
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);