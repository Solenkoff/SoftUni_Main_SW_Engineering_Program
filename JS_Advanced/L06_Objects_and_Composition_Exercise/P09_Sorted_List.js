function createSortedList() {
    const numList = [];

    return {
        add(number) {
            numList.push(number);
            numList.sort((a, b) => a - b);
        },
        get(index) {
            if (index >= 0 && index < numList.length) {
                return numList[index];
            }     
        },
        remove(index) {
            if (index >= 0 && index < numList.length) {
                numList.splice(index, 1);
            }
        },
        get size() {
            return numList.length;
        }
    }
}


let numList = createSortedList();
numList.add(5);
numList.add(6);
numList.add(7);
console.log(numList.get(1)); 
numList.remove(1);
console.log(numList.get(1));
console.log(numList.size);

// remove(index) {
//     if (index < 0 || index >= numList.length) {
//         throw new RangeError('Index is out of range');
//     }

//     numList.splice(index, 1);
// },