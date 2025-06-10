"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Product {
    static _productCount = 0;
    id;
    _name;
    _price;
    constructor(name, price) {
        this.name = name;
        this.price = price;
        Product._productCount++;
        this.id = Product.productCount;
    }
    static get productCount() {
        return Product._productCount;
    }
    get name() {
        return this._name;
    }
    set name(val) {
        if (val.length < 1) {
            throw new Error("Name must contain at least 1 character");
        }
        this._name = val;
    }
    get price() {
        return this._price;
    }
    set price(val) {
        if (val <= 0) {
            throw new Error("Price must be positive");
        }
        this._price = val;
    }
    getDetails() {
        return `ID: ${this.id}, Name: ${this.name}, Price: $${this.price}`;
    }
}
class Inventory {
    products;
    constructor() {
        this.products = [];
    }
    addProduct(product) {
        this.products.push(product);
    }
    listProducts() {
        let result = [];
        this.products.forEach(p => result.push(p.getDetails()));
        result.push(`Total products created: ${Product.productCount}`);
        return result.join('\n');
    }
}
// const inventory = new Inventory();
// const product1 = new Product("Laptop", 1200);
// const product2 = new Product("Phone", 800);
// inventory.addProduct(product1);
// inventory.addProduct(product2);
// console.log(inventory.listProducts());
// Product.productCount = 10;
// const product = new Product("", 800);
const product2 = new Product("Phone", 0);
// product.id = 5;
//# sourceMappingURL=inventory-system.js.map