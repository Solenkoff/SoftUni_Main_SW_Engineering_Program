function solve(inputArray) {
    let objects = {};

    inputArray.forEach((el) => {
        let [action, objName, ...params] = el.split(" ");
        if (action == "create" && params.length == 0) {
            objects[objName] = {};
        } else if (action == "create" && params.length != 0) {
            objects[objName] = Object.create(objects[params[1]]);
        } else if (action == "set") {
            objects[objName][params[0]] = params[1];
        } else if (action == "print") {
            print(objects[objName]);
        }
    });

    function print(print) {
        let result = [];
        for (let key in print) {
            result.push(`${key}:${print[key]}`);
        }
        console.log(result.join(","));
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