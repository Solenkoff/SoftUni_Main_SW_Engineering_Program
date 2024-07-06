import { expect } from 'chai';
import { planYourTrip } from './planYourTrip.js';

describe('Testing planYourTrip', () => {

    describe('Testing choosingDestination', () => {

        it('Wrong year sould throw', () => {
            expect(() => planYourTrip.choosingDestination('Varna', 'Winter', 2023)).to.throw('Invalid Year!');
        })

        it('Destination different then Ski Resort sould throw', () => {
            expect(() => planYourTrip.choosingDestination('Beach Resort', 'Winter', 2024)).to.throw('This destination is not what you are looking for.');
        })

        it('When season is Winter returns correct', () => {
            expect(planYourTrip.choosingDestination('Ski Resort', 'Winter', 2024)).to.equal('Great choice! The Winter is the perfect time to visit the Ski Resort.');
        })

        it('When season is Winter returns correct', () => {
            expect(planYourTrip.choosingDestination('Ski Resort', 'Summer', 2024)).to.equal('Consider visiting during the Winter for the best experience at the Ski Resort.');
        })
    })


    describe('Testing exploreOptions', () => {

        it('activities not an Array sould throw', () => {
            expect(() => planYourTrip.exploreOptions('String', 2)).to.throw('Invalid Information!');
        })

        it('Index is not a number sould throw', () => {
            expect(() => planYourTrip.exploreOptions(['One', 'Two'], 'String')).to.throw('Invalid Information!');
        })

        it('Index is not an integer sould throw', () => {
            expect(() => planYourTrip.exploreOptions(['One', 'Two'], 2.34)).to.throw('Invalid Information!');
        })

        it('Index out of the array sould throw', () => {
            expect(() => planYourTrip.exploreOptions(['One', 'Two'], 2)).to.throw('Invalid Information!');
        })

        it('Returns correct', () => {
            expect(planYourTrip.exploreOptions(['One', 'Two', 'Three'], 2)).to.equal('One, Two');
        })

    })

   
    describe('Testing estimateExpenses', () => {

        it('No numbers args sould throw', () => {
            expect(() => planYourTrip.estimateExpenses('500', '500')).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(500, '500')).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses('500', 500)).to.throw('Invalid Information!');
        })

        it('No numbers args sould throw', () => {
            expect(() => planYourTrip.estimateExpenses(undefined, 500)).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(500, undefined)).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(undefined, undefined)).to.throw('Invalid Information!');
        })

        

        it('No numbers args sould throw', () => {
            expect(() => planYourTrip.estimateExpenses(null, '500')).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(500, null)).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(null, null)).to.throw('Invalid Information!');
        })

        it('Negative args sould throw', () => {
            expect(() => planYourTrip.estimateExpenses(500, -500)).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(-500, 500 )).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(-500, -500 )).to.throw('Invalid Information!');
        })

        it('Zero args sould throw', () => {
            expect(() => planYourTrip.estimateExpenses(undefined, 0)).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(0, 500 )).to.throw('Invalid Information!');
            expect(() => planYourTrip.estimateExpenses(0, 0)).to.throw('Invalid Information!');
        })

        it('Cost under 500 returns correct', () => {
            expect(planYourTrip.estimateExpenses(100, 4)).to.equal('The trip is budget-friendly, estimated cost is $400.00.');
            expect(planYourTrip.estimateExpenses(100, 5)).to.equal('The trip is budget-friendly, estimated cost is $500.00.');
        })

        it('Cost over 500 returns correct', () => {
            expect(planYourTrip.estimateExpenses(100, 6)).to.equal('The estimated cost for the trip is $600.00, plan accordingly.');
            expect(planYourTrip.estimateExpenses(100, 22)).to.equal('The estimated cost for the trip is $2200.00, plan accordingly.');
        })

    })
})