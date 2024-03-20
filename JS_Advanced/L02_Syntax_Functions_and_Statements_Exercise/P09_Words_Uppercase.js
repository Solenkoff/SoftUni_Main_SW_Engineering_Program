function wordsUppercase(input){

    input = input.toUpperCase();
    const array = [...input.matchAll(/[A-Z0-9]+/g)];
    console.log(array.join(", "));

}

wordsUppercase('Hi, how are you?');