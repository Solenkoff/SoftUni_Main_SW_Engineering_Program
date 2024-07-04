import { expect } from 'chai';
import { findNewApartment } from './findApartment.js';

describe ('Test', () => {

    describe ('Tests for isGoodLocation', () => {
        it('City not a string throws', () => {
            expect(() => findNewApartment.isGoodLocation([], true)).to.throw('Invalid input!');
        })

        it('nearPublicTransportation not a boolean throws', () => {
            expect(() => findNewApartment.isGoodLocation('string', [])).to.throw('Invalid input!');
        })

        it('City different then Sofia, Plovdiv, Varns throws', () => {
            expect(findNewApartment.isGoodLocation('Shabla', true)).to.equal('This location is not suitable for you.');
        })

        it('nearPublicTransportation true returns correct', () => {
            expect(findNewApartment.isGoodLocation('Varna', true)).to.equal('You can go on home tour!');
        })

        it('nearPublicTransportation false returns correct', () => {
            expect(findNewApartment.isGoodLocation('Varna', false)).to.equal('There is no public transport in area.');
        })
    })


    describe ('Tests for isLargeEnough', () => {
        it('Apartments not array throws', () => {
            expect(() => findNewApartment.isLargeEnough('string', 44)).to.throw('Invalid input!');
        })

        it('Apartments empty array throws', () => {
            expect(() => findNewApartment.isLargeEnough([], 44)).to.throw('Invalid input!');
        })

        it('minimalSquareMeters not a number throws', () => {
            expect(() => findNewApartment.isLargeEnough([20,40], 'string')).to.throw('Invalid input!');
        })
       
        it('Valid apatrments return correct', () => {
            expect(findNewApartment.isLargeEnough([50,60], 40)).to.equal('50, 60');
        })

        it('Various apatrments return correct', () => {
            expect(findNewApartment.isLargeEnough([50,30,20,70], 40)).to.equal('50, 70');
        })

        it('Apatrment equal to minimalSquareMeters return correct', () => {
            expect(findNewApartment.isLargeEnough([40], 40)).to.equal('40');
        })
    })


    describe ('Tests for isItAffordable', () => {
        it('Price not a number throws', () => {
            expect(() => findNewApartment.isItAffordable('string', 4444)).to.throw('Invalid input!');
        })

        it('Price less or equal to Zero throws', () => {
            expect(() => findNewApartment.isItAffordable(-1, 4444)).to.throw('Invalid input!');
            expect(() => findNewApartment.isItAffordable(0, 4444)).to.throw('Invalid input!');
        })

        it('Budget not a number throws', () => {
            expect(() => findNewApartment.isItAffordable(4444, 'string')).to.throw('Invalid input!');
        })

        it('Budget less or equal to Zero throws', () => {
            expect(() => findNewApartment.isItAffordable(4444, -1)).to.throw('Invalid input!');
            expect(() => findNewApartment.isItAffordable(4444, 0)).to.throw('Invalid input!');
        })
       
        it('Budget less then price return correct', () => {
            expect(findNewApartment.isItAffordable(5555, 4444)).to.equal('You don\'t have enough money for this house!');
        })

        it('Budget less then price return correct', () => {
            expect(findNewApartment.isItAffordable(4444, 5555)).to.equal('You can afford this home!');
        })
    })
   
})