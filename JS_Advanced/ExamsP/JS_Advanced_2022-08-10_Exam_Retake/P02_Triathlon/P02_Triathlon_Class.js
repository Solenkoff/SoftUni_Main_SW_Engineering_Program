class Triathlon {

    constructor(competitionName) {
        this.competitionName = competitionName;
        this.participants = {};
        this.listOfFinalists = [];
    }

    addParticipant(participantName, participantGender) {
        if (this.participants[participantName]) {
            return `${participantName} has already been added to the list`;
        }

        this.participants[participantName] = participantGender;

        return `A new participant has been added - ${participantName}`;
    }

    completeness(participantName, condition) {


        if (!this.participants[participantName]) {
            throw new Error(`${participantName} is not in the current participants list`);
        }

        if (condition < 30) {
            throw new Error(`${participantName} is not well prepared and cannot finish any discipline`); //
        }

        let disciplinesCompleted = Math.floor(condition / 30);

        if (disciplinesCompleted < 3) {
            return `${participantName} could only complete ${disciplinesCompleted} of the disciplines`;
        } else {
            let participant = {
                name: participantName,
                gender: this.participants[participantName]
            };
            this.listOfFinalists.push(participant);
        }

        return `Congratulations, ${participantName} finished the whole competition`;
    }

    rewarding(participantName) {
        if (this.listOfFinalists.some(f => f.name == participantName)) {
            return `${participantName} was rewarded with a trophy for his performance`;
        } else {
            return `${participantName} is not in the current finalists list`;
        }
    }

    showRecord(criteria) {
        if (this.listOfFinalists.length == 0) {
            return 'There are no finalists in this competition';
        }

        if (criteria == 'all') {
            let result = [`List of all ${this.competitionName} finalists:`];
            let sortedNamesOfFinalists = this.listOfFinalists.map(f => f.name)
                                                             .sort((a, b) => a.localeCompare(b));
            result.push(...sortedNamesOfFinalists);

            return result.join('\n');
        } else if (!this.listOfFinalists.some(f => f.gender == criteria)) {
            return `There are no ${criteria}'s that finished the competition`;
        } else {
            let finalistsByCriteria = this.listOfFinalists.filter(f => f.gender == criteria)
                                                          .map(f => f.name);
            return `${finalistsByCriteria[0]} is the first ${criteria} that finished the ${this.competitionName} triathlon`;
        }
    }
}


const contest = new Triathlon("Dynamos");
console.log(contest.addParticipant("Peter", "male"));
console.log(contest.addParticipant("Sasha", "female"));
console.log(contest.addParticipant("George", "male"));
console.log(contest.completeness("Peter", 100));
console.log(contest.completeness("Sasha", 90));
console.log(contest.completeness("George", 95));
console.log(contest.rewarding("Peter"));
console.log(contest.rewarding("Sasha"));
console.log(contest.rewarding("George"));
console.log(contest.showRecord("male"));


