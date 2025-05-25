function isSumEven(firstInt: number, secondInt: number, thirdInt: number): boolean {
    const sum = firstInt + secondInt + thirdInt;

    return sum % 2 === 0;
}

console.log(isSumEven( 5, 8, 9));
console.log(isSumEven( 5, 7, 9));
