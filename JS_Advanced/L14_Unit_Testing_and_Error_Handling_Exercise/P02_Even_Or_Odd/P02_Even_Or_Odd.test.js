import { expect } from 'chai';
import { isOddOrEven } from './P02_Even_Or_Odd.js';

describe('Execution with NON STRING argument should return undefined', () => {

    it('It works', () => {
        expect(isOddOrEven('Even')).to.equal('even');
    });

    it('It works', () => {
        expect(isOddOrEven('Odd')).to.equal('odd');
    });

    it('It works', () => {
        expect(isOddOrEven([])).to.equal(undefined);
    });

    it('It works', () => {
        expect(isOddOrEven({})).to.equal(undefined);
    });

    it('It works', () => {
        expect(isOddOrEven(Number(5))).to.equal(undefined);
    });

    it('It works', () => {
        expect(isOddOrEven(true)).to.equal(undefined);
    });
});

describe('Correct behaviour', () => {

    it('String with even length', () => {
        expect(isOddOrEven('Even')).to.equal('even');
    });

    it('String with odd length', () => {
        expect(isOddOrEven('Odd')).to.equal('odd');
    });

    it('String with odd length', () => {
        expect(isOddOrEven('')).to.equal('even');
    });

    it('String with odd length', () => {
        let longOddString = 'Glsngllseiiniselvnlsnldfnlnslenlneslnlnselnpdofkgi';
        expect(isOddOrEven(longOddString)).to.equal('even');
    });

});