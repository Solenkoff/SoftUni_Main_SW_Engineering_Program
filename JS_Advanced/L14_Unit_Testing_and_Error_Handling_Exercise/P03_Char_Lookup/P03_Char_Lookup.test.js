import {expect} from 'chai';
import {lookupChar} from './P03_Char_Lookup.js';

describe('Testing Char_Lookup', () =>{
    describe('Testing invalid arguments', () => {
        
        it('A NON STRING first argument should return undefined', () => {
            expect(lookupChar(Number, 3)).to.equal(undefined);
        })

        it('A NON STRING first argument should return undefined', () => {
            expect(lookupChar([], 3)).to.equal(undefined);
        })

        it('A NON STRING first argument should return undefined', () => {
            expect(lookupChar({}, 3)).to.equal(undefined);
        })

        it('A NON STRING first argument should return undefined', () => {
            expect(lookupChar(true, 3)).to.equal(undefined);
        })

        it('A NON STRING first argument should return undefined', () => {
            expect(lookupChar('String', 3.14)).to.equal(undefined);
        })

        it('A NON NUMBER SECOND argument should return undefined', () => {
            expect(lookupChar('String', 'OtherString')).to.equal(undefined);
        })

        it('A NON NUMBER SECOND argument should return undefined', () => {
            expect(lookupChar('String', [])).to.equal(undefined);
        })

        it('A NON NUMBER SECOND argument should return undefined', () => {
            expect(lookupChar('String', {})).to.equal(undefined);
        })

        it('A NON NUMBER SECOND argument should return undefined', () => {
            expect(lookupChar('String', true)).to.equal(undefined);
        })

        it('NON Valid BOTH arguments', () => {
            expect(lookupChar([], -1)).to.equal(undefined);
        })
      
    })

    describe('Testing Index is in RANGE', () => {
        it('Index less then Zero should retern message', () => {
            expect(lookupChar('String', -1)).to.equal('Incorrect index');
        })

        it('Index equal or higher then String.length should retern message', () => {
            expect(lookupChar('String', 6)).to.equal('Incorrect index');
        })

        it('Index equal or higher then String.length should retern message', () => {
            expect(lookupChar('String', 111)).to.equal('Incorrect index');
        })

    })

    describe('Testing Correct behaviour', () => {
        it('Returns correct string', () => {
            expect(lookupChar('String', 2)).to.equal('r');
        })

    })
})