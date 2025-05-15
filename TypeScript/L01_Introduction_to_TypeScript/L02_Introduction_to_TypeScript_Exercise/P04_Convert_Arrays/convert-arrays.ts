function convertArrays( input: string[] ): [string, number] {
    const text = input.join('');
    const length = text.length;

    return [text, length];

}

console.log(convertArrays(['How', 'are', 'you?']));
console.log(convertArrays(['Today', ' is', ' a ', 'nice', ' ', 'day for ', 'TypeScript']));
