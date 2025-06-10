function summerizePerson( 
    id: number,
    firstName: string,
    lastName: string,
    age: number,
    middleName?: string,
    hobbies?: string[],
    workingInfo?: [string, number]
): [number, string, number, string, string] {
    
    const fullName = middleName ? `${firstName} ${middleName} ${lastName}` : `${firstName} ${lastName}`;
    const hobbiesString = hobbies && hobbies.length > 0 ? hobbies.join(', ') : '-';
    const jobInfoString = workingInfo ? `${workingInfo[0]} -> ${workingInfo[1]}` : '-';

    return [id, fullName, age, hobbiesString, jobInfoString];
}

console.log(summerizePerson(12, 'Eliot', 'Des', 20, 'Braylen', ['tennis', 'football', 'hiking'], ['Sales Consultant', 2500]));
console.log(summerizePerson(20, 'Mary', 'Trent', 25, undefined, ['fitness', 'rowing']));
console.log(summerizePerson(21, 'Joseph', 'Angler', 28));
console.log(summerizePerson(21, 'Kristine', 'Neva', 23, ''));
