let { movieTheater } = require("./movieTheater");
let { expect } = require("chai");

describe("Tests movieTheater", () => {
    describe("Tests for ageRestrictions()", () => {

        it("Should return correct, when movieRating is G", () => {
            expect(movieTheater.ageRestrictions('G')).to.equal('All ages admitted to watch the movie');
        });

        it("Should return correct, when movieRating is PG", () => {
            expect(movieTheater.ageRestrictions('PG')).to.equal('Parental guidance suggested! Some material may not be suitable for pre-teenagers');
        });

        it("Should return correct, when movieRating is R", () => {
            expect(movieTheater.ageRestrictions('R')).to.equal('Restricted! Under 17 requires accompanying parent or adult guardian');
        });

        it("Should return correct, when movieRating is NC-17", () => {
            expect(movieTheater.ageRestrictions('NC-17')).to.equal('No one under 17 admitted to watch the movie');
        });

        it("Should return correct, when movieRating is Enithing Else", () => {
            expect(movieTheater.ageRestrictions('SomthingElse')).to.equal('There are no age restrictions for this movie');
            expect(movieTheater.ageRestrictions('')).to.equal('There are no age restrictions for this movie');
            expect(movieTheater.ageRestrictions('-=+*')).to.equal('There are no age restrictions for this movie');
        });
    });

    describe("Tests for moneySpent()", () => {
        let food = ['Nachos', 'Popcorn'];
        let drinks = ['Soda',  'Water'];

        it("It should throw, when tikets is not a number", () => {
            expect(() => movieTheater.moneySpent('Word', food, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(['Word'], food, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent({key:'Word'}, food, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(true, food, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(undefined, food, drinks)).to.throw('Invalid input');
        });

        it("It should throw, when food is not an array", () => {
            expect(() => movieTheater.moneySpent(14, 67, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14, 'Word', drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14, {key:'Word'}, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14, undefined, drinks)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14, true, drinks)).to.throw('Invalid input');
        });

        it("It should throw, when drinks is not an array", () => {
            expect(() => movieTheater.moneySpent(14,food, 67)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14,food, 'Word')).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14,food, {key:'Word'})).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14,food, undefined)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(14,food, true)).to.throw('Invalid input');
        });

        it("It should return correct, when total cost is bigger than 50", () => {
            expect(movieTheater.moneySpent(4,food, drinks)).to.equal('The total cost for the purchase with applied discount is 59.60');
        });

        it("It should return correct, when total cost is less than 50", () => {
            expect(movieTheater.moneySpent(1,food, drinks)).to.equal('The total cost for the purchase is 29.50');
        });
    });

    describe("Tests for reservation()", () => {
        it("It should throw, when rowsArray is NOT an arrray", () => {
            expect(() => movieTheater.reservation(4, 4)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent('Word', 4)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent({key:'Word'}, 4)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(true, 4)).to.throw('Invalid input');
            expect(() => movieTheater.moneySpent(undefined, 4)).to.throw('Invalid input');
        });

        it("It should throw, when neededSeatsCount is NOT a number", () => {
            expect(() => movieTheater.reservation([1,2,3], [4,5,6])).to.throw('Invalid input');
            expect(() => movieTheater.reservation([1,2,3], 'Word')).to.throw('Invalid input');
            expect(() => movieTheater.reservation([1,2,3], {key:'Word'})).to.throw('Invalid input');
            expect(() => movieTheater.reservation([1,2,3], true)).to.throw('Invalid input');
            expect(() => movieTheater.reservation([1,2,3], undefined)).to.throw('Invalid input');
        });

        it("It should return correct", () => {
            expect(movieTheater.reservation([
                { rowNumber: 1, freeSeats: 3 }, 
                { rowNumber: 2, freeSeats: 8 }, 
                { rowNumber: 3, freeSeats: 7 }
            ], 8)).to.equal(2);                              
        });
    });
    
});
