function solution() {
    let resultString = '';

    return {
        append: (subString) => resultString += subString,
        removeStart: (nChars) => resultString = resultString.slice(nChars),
        removeEnd: (nChars) => resultString = resultString.slice(0, -nChars),
        print: () => console.log(resultString)
    }
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();