"use strict";
// //*  ---  Generic Functions  ---
Object.defineProperty(exports, "__esModule", { value: true });
// function getFirstElement<T>(arr: T[]): T {
//     return arr[0];
// }
// const firstEl = getFirstElement(['Pesho', 22]);
// const firstNumEl = getFirstElement([45, 234, -19]);
// console.log(firstNumEl.toFixed(2));;
// //*  ---  Generic Functions with 2 type parameter  ---
// function makeTuple<T, U>(el1: T, el2: U): [T, U] {
//     return [el1, el2];
// }
// const tuple1 = makeTuple<string, number>('Pesho', 23);
// console.log(tuple1);
// const tuple2 = makeTuple<number, boolean>(4, false);
// console.log(tuple2);
// //*  ---  Generic Interfaces  ---
// interface Message<T> {
//     sender: string;
//     recipient: string;
//     data: T;
// };
// const message1: Message<string> = {
//     sender: 'Pesho',
//     recipient: 'Tosho',
//     data: 'Hello there!'
// };
// // type MessageDataType = { text: string, timestamp: number };
// // const message2: Message<{ MessageDataType }> = {              //*  as the following with TYPE
// const message2: Message<{ text: string, timestamp: number }> = {
//     sender: 'Gana',
//     recipient: 'Pena',
//     data: { text: 'Hi, whats up', timestamp: 23423424 }
// };
// console.log(message2.data.text);   //*  =>  'Hi, whats up'
// //*  ---  Generic type constraints  ---
// function logItemId<T extends { id: number }>(item: T): void {
//     console.log(item);
// }
// // logItemId('Pesho');             //*  without 'extend'
// // logItemId(23);
// // logItemId({ name: 'Pesho' });
// logItemId({ id: 2, name: 'Pesho', age: 20 });
// logItemId({ id: 2, email: 'pesho@abv.bg' });
// //*  ---  Generic class with ! type parameter
// class StorageBox<T> {
//     items: T[] = [];
//     constructor( initialItems: T[]) {
//         this.items = initialItems;
//     }
//     getAllItems(): T[]  {
//         return this.items;
//     }
//     getFirstItem(): T{
//         return this.items[0];
//     }
//     addItem(newItem: T): void {
//         this.items.push(newItem);
//     }
//     reverseItems(): void {
//         this.items.reverse();
//     }
//     removeItem(item: T): void {
//         const index = this.items.indexOf(item);
//         if(index > -1){
//             this.items.splice(index, 1);
//         }
//     }
// }
// const box1 = new StorageBox<string>(['Pesho', 'Mincho']);  
// box1.addItem('Ginka');
// box1.addItem('Stavrulka'); 
// box1.removeItem('Mincho');
// box1.reverseItems();
// console.log(box1.getAllItems());
// console.log(box1.getFirstItem());
//*   -----------------------------------------
class ApiResponse {
    isSuccessful;
    data;
    error;
    constructor(isSuccessful, data, error) {
        this.isSuccessful = isSuccessful;
        this.data = data;
        this.error = error;
    }
    getResult() {
        if (!this.isSuccessful || this.data === null) {
            throw new Error(String(this.error));
        }
        return this.data;
    }
}
const userResponse1 = new ApiResponse(true, 'pesho', null);
const userResponse2 = new ApiResponse(true, ['pesho', 'gosho', 'tosho'], null);
const userResponse3 = new ApiResponse(false, null, 'Unknown error');
console.log(userResponse2.getResult());
console.log(userResponse3.getResult());
//# sourceMappingURL=demo.js.map