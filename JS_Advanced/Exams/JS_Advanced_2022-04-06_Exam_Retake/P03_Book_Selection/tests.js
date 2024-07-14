let {bookSelection} = require('./bookSelection.js');
let { expect} = require('chai');

describe("Tests for bookSelection", () => {
    describe("Tests for isGenreSuitable", () => {

        it('It sould throw, when Age is below 12 and genre is Thriller', () => {
            expect(() => bookSelection.isGenreSuitable('Thriller', 0).to.throw(`Books with Thriller genre are not suitable for kids at 8 age`));
        });
        it('It sould throw, when Age is below 12 and genre is Thriller', () => {
            expect(() => bookSelection.isGenreSuitable('Thriller', 8).to.throw(`Books with Thriller genre are not suitable for kids at 8 age`));
        });
        it('It sould throw, when Age is below 12 and genre is Thriller', () => {
            expect(() => bookSelection.isGenreSuitable('Thriller', 12).to.throw(`Books with Thriller genre are not suitable for kids at 12 age`));
        });
        it('It sould throw, when Age is below 12 and genre is Thriller', () => {
            expect(() => bookSelection.isGenreSuitable('Horror', 8).to.throw(`Books with Horror genre are not suitable for kids at 8 age`));
        });
        it('It sould throw, when Age is below 12 and genre is Thriller', () => {
            expect(() => bookSelection.isGenreSuitable('Horror', 12).to.throw(`Books with Horror genre are not suitable for kids at 12 age`));
        });
        it('It sould return correct, when data is suitable', () => {
            expect(bookSelection.isGenreSuitable('Drama', 12)).to.equal(`Those books are suitable`);
        });
        it('It sould return correct, when data is suitable', () => {
            expect(bookSelection.isGenreSuitable('Drama', 8)).to.equal(`Those books are suitable`);
        });
        it('It sould return correct, when data is suitable', () => {
            expect(bookSelection.isGenreSuitable('Horror', 44)).to.equal(`Those books are suitable`);
        });

     });

     describe("Tests for isItAffordable", () => {

        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable('price', 24).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable([price], 24).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable({price}, 24).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(true, 24).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(undefined, 24).to.throw(`Invalid input`));
        });

        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(24, 'price').to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(24, [price]).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(24, {price}).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(24, true).to.throw(`Invalid input`));
        });
        it('It sould throw, when Price or Budget are not numbers', () => {
            expect(() => bookSelection.isItAffordable(24, undefined).to.throw(`Invalid input`));
        });

        it('It sould return correct, when Price is higher than Budget', () => {
            expect(bookSelection.isItAffordable(24, 23)).to.equal(`You don't have enough money`);
        });

        it('It sould return correct, when Price is NOT higher than Budget', () => {
            expect(bookSelection.isItAffordable(24, 24)).to.equal(`Book bought. You have 0$ left`);
        });
        it('It sould return correct, when Price is NOT higher than Budget', () => {
            expect(bookSelection.isItAffordable(24, 27)).to.equal(`Book bought. You have 3$ left`);
        });

     });

     describe("Tests for suitableTitles(array, wantedGenre)", () => {

        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles(8, 'genre').to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles('array', 'genre').to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles({array}, 'genre').to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles(true, 'genre').to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles(undefined, 'genre').to.throw(`Invalid input`));
        });

        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles([array], 8).to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles([array], {obj}).to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles([array], {array}).to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles([array], true).to.throw(`Invalid input`));
        });
        it('It sould throw, when Books is not an array or wantedGenre is not string', () => {
            expect(() => bookSelection.suitableTitles([array], undefined).to.throw(`Invalid input`));
        });



        it('It sould return correct, when Books IS an array and wantedGenre IS string', () => {
            let bookOne = { title: "The Da Vinci Code", genre: "Thriller" };
            let bookTwo = { title: "The Matrix", genre: "CiFi" };
            let bookThree = { title: "Windfall", genre: "Thriller" };
            let books = [bookOne,bookTwo,bookThree];
            let expected = ['The Da Vinci Code', 'Windfall'];
            expect(bookSelection.suitableTitles(books, 'Thriller')).to.deep.equal(expected);
        });
       
     });
     
});
