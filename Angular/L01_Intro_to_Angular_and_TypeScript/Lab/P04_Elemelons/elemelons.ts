abstract class Melon {
    public weight: number;
    public melonSort: string;
    protected element: string;

    constructor(weight: number, melonSort: string) {
        this.weight = weight;
        this.melonSort = melonSort;
        this.element = '';
    }

    public get elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public toString(): string {
        return `Element: ${this.element}
Sort: ${this.melonSort}
Element Index: ${this.elementIndex}`;
    }
}

class Watermelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.element = 'Water';
    }
}

class Firemelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.element = 'Fire';
    }
}

class Earthmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.element = 'Earth';
    }
}

class Airmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.element = 'Air';
    }
}

class Melolemonmelon extends Watermelon {
    private elements: string[];
    private currentIndex: number;

    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);

        this.elements = ['Water', 'Fire', 'Earth', 'Air'];
        this.currentIndex = 0;
        this.element = this.elements[this.currentIndex];
    }

    public morph(): void {
        this.currentIndex++;

        if (this.currentIndex >= this.elements.length) {
            this.currentIndex = 0;
        }

        this.element = this.elements[this.currentIndex];
    }
}


let watermelon : Watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());
