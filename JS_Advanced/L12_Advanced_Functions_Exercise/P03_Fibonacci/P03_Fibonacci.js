function getFibonator() {
    var arr = [0, 1];
    return () => {
        let num = arr[arr.length - 1]
        let len = arr.length;

        arr.push(arr[len - 1] + arr[len - 2]);
        return num;
    };
};

//----  Variant 2   ----------

// function getFibonator() {
//     let prev = 0;
//     let curr = 1;
//     return function () {
//         let next = prev + curr;
//         prev = curr;
//         curr = next;
//         return prev;
//     };
// }

//------------------------------------

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
