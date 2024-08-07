class OnlineShop{

    constructor(warehouseSpace) {
        this.warehouseSpace = warehouseSpace;
        this.products  = [];
        this.sales = [];
    }


    loadingStore(product, quantity, spaceRequired){
        if(spaceRequired > this.warehouseSpace){
            throw new Error('Not enough space in the warehouse.');
        }

        const newProduct = {
            product,
            quantity,
        }

        this.products.push(newProduct);
        this.warehouseSpace -= spaceRequired;

        return `The ${product} has been successfully delivered in the warehouse.`;
    }

    quantityCheck(product, minimalQuantity){
        let currProduct = this.products.find(p => p.product == product);

        if(!currProduct){
            throw new Error(`There is no ${product} in the warehouse.`);
        }
        if(minimalQuantity <= 0){
            throw new Error('The quantity cannot be zero or negative.');
        }
        if(minimalQuantity <= currProduct.quantity){
            return `You have enough from product ${product}.`;
        }

        const diff = minimalQuantity - currProduct.quantity;
        currProduct.quantity = minimalQuantity;

        return `You added ${diff} more from the ${product} products.`;
    }

    sellProduct(product) {
        let currProduct = this.products.find(p => p.product == product);

        if(!currProduct){
            throw new Error(`There is no ${product} in the warehouse.`);
        }

        currProduct.quantity --;

        const soldProduct = {
            product,
            quantity: 1
        }

        this.sales.push(soldProduct);

        return `The ${product} has been successfully sold.`;
    }

    revision(){
        let info = [];

        if(this.sales.length == 0){
            throw new Error('There are no sales today!');
        }else{
            info.push(`You sold ${this.sales.length} products today!`)
        }

        info.push('Products in the warehouse:');
        this.products.map(p => `${p.product}-${p.quantity} more left`).forEach(p => info.push(p));

        return info.join('\n');
    }

}

const myOnlineShop = new OnlineShop(500)
console.log(myOnlineShop.loadingStore('headphones', 10, 200));
console.log(myOnlineShop.loadingStore('laptop', 5, 200));

console.log(myOnlineShop.quantityCheck('headphones', 10));
console.log(myOnlineShop.quantityCheck('laptop', 10));

console.log(myOnlineShop.sellProduct('headphones'));
console.log(myOnlineShop.sellProduct('laptop'));
console.log(myOnlineShop.revision());
