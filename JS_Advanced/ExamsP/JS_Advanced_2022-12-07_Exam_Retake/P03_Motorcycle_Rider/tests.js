let { motorcycleRider } = require("./motorcycleRider");
let { expect } = require("chai");


describe("Tests for motorcycleRider", () => {
    describe("Tests for licenseRestriction", () => {

        it("Should return correct, when category is AM", () => {
            expect(motorcycleRider.licenseRestriction('AM')).to.equal('Mopeds with a maximum design speed of 45 km. per hour, engine volume is no more than 50 cubic centimeters, and the minimum age is 16.');
        });
        it("Should return correct, when category is AM", () => {
            expect(motorcycleRider.licenseRestriction('A1')).to.equal('Motorcycles with engine volume is no more than 125 cubic centimeters, maximum power of 11KW. and the minimum age is 16.');
        });
        it("Should return correct, when category is AM", () => {
            expect(motorcycleRider.licenseRestriction('A2')).to.equal('Motorcycles with maximum power of 35KW. and the minimum age is 18.');
        });
        it("Should return correct, when category is AM", () => {
            expect(motorcycleRider.licenseRestriction('AM')).to.equal('Mopeds with a maximum design speed of 45 km. per hour, engine volume is no more than 50 cubic centimeters, and the minimum age is 16.');
        });
        it("Should throw, when category is incorrect", () => {
            expect(() => motorcycleRider.licenseRestriction('Brr')).to.throw('Invalid Information!');
        });
    });

    describe("Tests for motorcycleShowroom", () => {
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom('array', 250)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom(250, 250)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom({ 150: 150, 250: 250 }, 250)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom(true, 250)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([150, 250], 'string')).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([150, 250], { 150: 150, 250: 250 })).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([150, 250], [150, 250])).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([150, 250], true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([], 250)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.motorcycleShowroom([150, 250], 49)).to.throw('Invalid Information!');
        });

    });

    describe("Tests for otherSpendings", () => {
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], [150, 250], 49)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], [150, 250], 'string')).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], [150, 250], [150, 250])).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], [150, 250], { 150: 150, 250: 250 })).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], [150, 250], undefined)).to.throw('Invalid Information!');
        });

        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings('string', [150, 250], true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings({ 150: 150, 250: 250 }, [150, 250], true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings(568, [150, 250], true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings(true, [150, 250], true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings(undefined, [150, 250], true)).to.throw('Invalid Information!');
        });

        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], 'string', true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], { 150: 150, 250: 250 }, true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], Number(57), true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], true, true)).to.throw('Invalid Information!');
        });
        it("Should throw, when incorrect data", () => {
            expect(() => motorcycleRider.otherSpendings([150, 250], undefined, true)).to.throw('Invalid Information!');
        });

        it("It should return correct", () => {
            expect(motorcycleRider.otherSpendings(["helmet"], ["engine oil"], false)).to.equal(`You spend $270.00 for equipment and consumables!`);
        });
        it("It should return correct", () => {
            expect(motorcycleRider.otherSpendings(["helmet", 'jacked'], ["engine oil", 'oil filter'], false)).to.equal(`You spend $600.00 for equipment and consumables!`);
        });

        it("It should return correct", () => {
            expect(motorcycleRider.otherSpendings(["helmet"], ["engine oil"], true)).to.equal(`You spend $243.00 for equipment and consumables with 10% discount!`);
        });
        it("It should return correct", () => {
            expect(motorcycleRider.otherSpendings(["helmet", 'jacked'], ["engine oil", 'oil filter'], true)).to.equal(`You spend $540.00 for equipment and consumables with 10% discount!`);
        });
        

    });


});
