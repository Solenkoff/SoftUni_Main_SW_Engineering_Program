"use strict";
function summerizePerson(id, firstName, lastName, age, middleName, hobbies, workingInfo) {
    const fullName = middleName ? `${firstName} ${middleName} ${lastName}` : `${firstName} ${lastName}`;
    const hobbiesString = hobbies && hobbies.length > 0 ? hobbies.join(', ') : '-';
    const jobInfo = workingInfo ? `${workingInfo[0]} -> ${workingInfo[1]}` : '-';
    return [id, fullName, age, hobbiesString, jobInfo];
}
console.log(summerizePerson(12, 'Eliot', 'Des', 20, 'Braylen', ['tennis', 'football', 'hiking'], ['Sales Consultant', 2500]));
console.log(summerizePerson(20, 'Mary', 'Trent', 25, undefined, ['fitness', 'rowing']));
console.log(summerizePerson(21, 'Joseph', 'Angler', 28));
console.log(summerizePerson(21, 'Kristine', 'Neva', 23, ''));
//# sourceMappingURL=summerize-person.js.map