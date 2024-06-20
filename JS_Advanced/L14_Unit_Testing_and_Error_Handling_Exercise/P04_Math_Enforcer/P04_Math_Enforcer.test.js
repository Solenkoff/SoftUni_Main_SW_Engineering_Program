import {expect} from 'chai';
import {mathEnforcer} from './P04_Math_Enforcer.js';

describe('Testing Math_Enforcer', () =>{
    describe('Testing addFive', () => {
        
        it('A NON Number argument should return undefined', () => {
            expect(mathEnforcer.addFive([])).to.equal(undefined);
            expect(mathEnforcer.addFive({})).to.equal(undefined);
            expect(mathEnforcer.addFive(true)).to.equal(undefined);
            expect(mathEnforcer.addFive('String')).to.equal(undefined);
        })

        it('A valid argument should add correctly', () => {
            expect(mathEnforcer.addFive(8)).to.equal(13);
            expect(mathEnforcer.addFive(-8)).to.equal(-3);
            expect(mathEnforcer.addFive(2.11)).to.be.closeTo(7.11, 0.01);
        })

    })

    describe('Testing subtractTen', () => {
        
        it('A NON Number argument should return undefined', () => {
            expect(mathEnforcer.subtractTen([])).to.equal(undefined);
            expect(mathEnforcer.subtractTen({})).to.equal(undefined);
            expect(mathEnforcer.subtractTen(true)).to.equal(undefined);
            expect(mathEnforcer.subtractTen('String')).to.equal(undefined);
        })

        it('A valid argument should add correctly', () => {
            expect(mathEnforcer.subtractTen(13)).to.equal(3);
            expect(mathEnforcer.subtractTen(-13)).to.equal(-23);
            expect(mathEnforcer.subtractTen(13.22)).to.be.closeTo(3.22, 0.01);
        })

    })

    describe('Testing sum', () => {
        
        it('Any NON Number argument should return undefined', () => {
            expect(mathEnforcer.sum([], 7)).to.equal(undefined);
            expect(mathEnforcer.sum({}, 7)).to.equal(undefined);
            expect(mathEnforcer.sum(true, 7)).to.equal(undefined);
            expect(mathEnforcer.sum('String', 7)).to.equal(undefined);
        })

        it('Any NON Number argument should return undefined', () => {
            expect(mathEnforcer.sum(7, [])).to.equal(undefined);
            expect(mathEnforcer.sum(7, {})).to.equal(undefined);
            expect(mathEnforcer.sum(7, true)).to.equal(undefined);
            expect(mathEnforcer.sum(7, 'String')).to.equal(undefined);
        })

        it('Valid arguments should be summed correctly', () => {
            expect(mathEnforcer.sum(13, 7)).to.equal(20);
            expect(mathEnforcer.sum(-13, -7)).to.equal(-20);
            expect(mathEnforcer.sum(13, -7)).to.equal(6);
            expect(mathEnforcer.sum(2.13, 1.07)).to.equal(3.2);
            expect(mathEnforcer.sum(2.13, 1.07)).to.be.closeTo(3.21, 0.01);
        })

    })

})