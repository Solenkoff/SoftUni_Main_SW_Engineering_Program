function formatPerson(person:[string, number]): string {
    return `Hello, my name is ${person[0]} and my age is ${person[1]}`;
}

console.log(formatPerson(['Ivan', 20]));
// console.log(formatPerson(['Ivan', 20, 'Ivanov']));
// console.log(formatPerson(['Joro', '25']));