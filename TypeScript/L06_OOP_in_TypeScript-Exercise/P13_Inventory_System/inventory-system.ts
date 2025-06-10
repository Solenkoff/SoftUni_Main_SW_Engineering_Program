class Product {

    private static _productCount: number = 0;
    readonly id: number;
    private _name!: string;
    private _price!: number;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
        Product._productCount++;
        this.id = Product.productCount;
    }

    static get productCount(): number {
        return Product._productCount
    }

    get name() {
        return this._name;
    }

    set name(val: string) {
        if (val.length < 1) {
            throw new Error("Name must contain at least 1 character");
        }
        this._name = val;
    }

    get price() {
        return this._price;
    }

    set price(val: number) {
        if (val <= 0) {
            throw new Error("Price must be positive");
        }
        this._price = val;
    }

    getDetails(): string {
        return `ID: ${this.id}, Name: ${this.name}, Price: $${this.price}`;
    }

}

class Inventory {
    private products: Product[];

    constructor() {
        this.products = [];
    }

    addProduct(product: Product): void {
        this.products.push(product);
    }

    listProducts(): string {
        let result: string[] = [];

        this.products.forEach(p =>
            result.push(p.getDetails())
        )

        result.push(`Total products created: ${Product.productCount}`)

        return result.join('\n');
    }
}

const inventory = new Inventory();
const product1 = new Product("Laptop", 1200);
const product2 = new Product("Phone", 800);

inventory.addProduct(product1);
inventory.addProduct(product2);

console.log(inventory.listProducts());


// Product.productCount = 10;
// const product = new Product("", 800);
// const product2 = new Product("Phone", 0);
//  product.id = 5;
