function listOfNames(arr){
    arr.sort((a,b) => a.localeCompare(b));

    for (let i = 0; i < arr.length; i++) {
        console.log(`${i + 1}.${arr[i]}`);
    }

    // arr.sort((a, b) => a.localeCompare(b))
    //     .forEach((name, i) => console.log(`${i + 1}.${name}`));
}

listOfNames(["John", "Bob", "Christina", "Ema"]);