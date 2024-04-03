function sortByTwoCriteria(arr){
    arr.sort((a, b) => a.localeCompare(b))
       .sort((a, b) => a.length - b.length)
       .forEach(el => console.log(el));
}

sortByTwoCriteria(['alpha', 'beta', 'gamma']);
sortByTwoCriteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortByTwoCriteria(['test', 'Deny', 'omen', 'Default']);
