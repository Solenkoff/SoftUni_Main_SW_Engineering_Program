function sameNums(inputNums) {
    const nums = inputNums.toString().split('').map(x => Number(x));
    let sum = nums[0];
    let allAreSame = true;

    for (let i = 1; i < nums.length; i++) {
        sum += nums[i];

        if (nums[i] !== nums[i - 1]) {
            allAreSame = false;
        }
    }

    console.log(allAreSame);
    console.log(sum);
}

sameNums(2222222);
sameNums(12344);