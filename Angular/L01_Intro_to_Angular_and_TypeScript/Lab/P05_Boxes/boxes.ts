class Box<T> {
    private elements: T[] = [];

    add(el: T): void {
        this.elements.push(el);
    }

    remove(): void {
        this.elements.pop();
    }

    get count(): number {
        return this.elements.length;
    }
}




let box = new Box<Number>();
box.add(1);
box.add(2);
box.add(3);
console.log(box.count);


// let box = new Box<String>();
// box.add("Pesho");
// box.add("Gosho");
// console.log(box.count);
// box.remove();
// console.log(box.count);
