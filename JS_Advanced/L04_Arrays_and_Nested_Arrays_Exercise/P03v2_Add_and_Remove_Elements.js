function addRemoveElements(arr){
    let num = 1;
    let result = [];
   
    const command = {
        add() { result.push(num)},
        remove() {result.pop()}
    };

    arr.forEach(x => {
        command[x]();
        num++;
    })

    result.length == 0
        ? console.log('Empty')
        : result.forEach(x => console.log(x));
}

addRemoveElements(['add', 'add', 'add', 'add']);
addRemoveElements(['add', 'add', 'remove', 'add', 'add']);
addRemoveElements(['remove', 'remove', 'remove']);