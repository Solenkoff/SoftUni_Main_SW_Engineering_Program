function addRemoveElements(arr){
    let num = 1;
    let resultArr = [];

    arr.forEach(command => {
        if(command === 'add'){
            resultArr.push(num);
        }else if(command === 'remove'){
            resultArr.pop();
        }
        num++
    });     
    
    if (resultArr.length){
        resultArr.forEach(x => console.log(x));
    }else{
        console.log('Empty');
    }
}

addRemoveElements(['add', 'add', 'add', 'add']);
addRemoveElements(['add', 'add', 'remove', 'add', 'add']);
addRemoveElements(['remove', 'remove', 'remove']);
