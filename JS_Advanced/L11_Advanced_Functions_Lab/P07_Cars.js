function solve(inputCommands){      //  !!!  Not Solved  !!!
    let objects = {};

    const commands = {
        create: (name) => objects[name] = {},
        createAndInherit: (name, parentName) => objects[name] = objects[parentName],
        set: (name, key, value) => objects[name][key] = value,
        print: (name) => console.log(Object.entries(objects).map((key,value) => `${key}:${value}`).join(',')) 
    }

    for (const fullCommand of inputCommands) {
        let [command, name, prop, value] = [...fullCommand.split(' ')];
        if(prop == 'inherit'){
            command = 'createAndInherit';
        }
        commands[command](name, prop, value);
    }
}

solve(
    ['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']

);