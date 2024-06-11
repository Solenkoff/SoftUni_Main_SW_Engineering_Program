function solve(arr){

    let innerList = [];

    const commands = {
        add: (string) => innerList.push(string),
        remove: (string) => innerList = innerList.filter(x => x !== string),
        print: () => console.log(innerList.join(','))
    }

    for (const el of arr) {
        const [command, arg] = el.split(' ');
        commands[command](arg);
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);