const trainFunc = () => console.log('Train');
const dineFunc = () => console.log('Dain');
const sleepFunc = () => console.log('Sleep');

type Train = { train:() => void, number: 1 } & ({hallway: 'A', pass?: 'Guest'} | {hallway: 'C'});
// type TrainC = { train:() => void, number: 1, hallway: 'C'};
type Dine = { dine:() => void, number: 2 } & ({hallway: 'A', pass?: 'Guest'} | {hallway: 'C'});
// type DineC = { dine:() => void, number: 2, hallway: 'C'};
type Sleep = { sleep:() => void, number: 3, hallway: 'A' | 'C'};
// type Floor = TrainA | TrainC | DineA | DineC | Sleep;
type Floor = Train | Dine | Sleep;

function visitFloor(floor: Floor) {
    switch (floor.number) {
        case 1: floor.train(); return;
        case 2: floor.dine(); return;
        case 3: floor.sleep(); return;
    }
}

//*   Working Calls
visitFloor({ train() { (trainFunc()) }, number: 1, hallway: 'A', pass: 'Guest' });
visitFloor({ dine() { dineFunc() }, number: 2, hallway: 'A' });
visitFloor({ sleep() { sleepFunc() }, number: 3, hallway: 'C' });
visitFloor({ train() { trainFunc() }, number: 1, hallway: 'C' });
visitFloor({ train() { trainFunc() }, number: 1, hallway: 'A' });
visitFloor({ dine() { dineFunc() }, number: 2, hallway: 'A', pass: 'Guest' });
visitFloor({ sleep() { sleepFunc() }, number: 3, hallway: 'A' });
visitFloor({ dine() { dineFunc() }, number: 2, hallway: 'C' });


//!  Type Error Calls
// visitFloor({ train() { }, number: 4, hallway: 'A' });
// visitFloor({ train() { }, number: 1, hallway: 'C', pass: 'Guest' });
// visitFloor({ train() { }, number: 2, hallway: 'A' });
// visitFloor({ train() { }, number: 3, hallway: 'C' });
// visitFloor({ train() { }, number: 3, hallway: 'C', pass: 'Guest' });

// visitFloor({ dine() { }, number: 1, hallway: 'A' });
// visitFloor({ dine() { }, number: 1, hallway: 'B' });
// visitFloor({ dine() { }, number: 1, hallway: 'C' });
// visitFloor({ dine() { }, number: 3, hallway: 'C' });
// visitFloor({ dine() { }, number: 2, hallway: 'C', pass: 'Guest' });
// visitFloor({ dine() { }, number: 1, hallway: 'A', pass: 'Guest' });

// visitFloor({ sleep() { }, number: 3, hallway: 'D' });
// visitFloor({ sleep() { }, number: 4, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'C' });
