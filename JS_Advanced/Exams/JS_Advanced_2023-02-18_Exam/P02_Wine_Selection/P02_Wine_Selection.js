class WineSelection{
    space;
    wines = [];
    bill = 0;

    constructor(space){
        this.space = space;
    }


    reserveABottle (wineName, wineType, price){
        if(this.space == 0){
            throw new Error('Not enough space in the cellar.');
        }

        const currWine = {
            wineName,
            wineType,
            price,
            paid: false
        }

        this.wines.push(currWine);
        this.space --;

        return `You reserved a bottle of ${wineName} ${wineType} wine.`;
    }

    payWineBottle( wineName, price ) {
        const wine = this.wines.find(w => w.wineName == wineName);

        if(!wine){
            throw new Error(`${wineName} is not in the cellar.`);
        }
        if(wine.paid){
            throw new Error(`${wineName} has already been paid.`);
        }

        wine.paid = true;
        this.bill += price;

        return `You bought a ${wineName} for a ${price}$.`;
    }


    openBottle(wineName) {
        const wine = this.wines.find(w => w.wineName == wineName);

        if(!wine){
            throw new Error(`The wine, you're looking for, is not found.`);
        }
        if(!wine.paid){
            throw new Error(`${wineName} need to be paid before open the bottle.`)
        }

        this.wines = this.wines.filter(w => w.wineName != wineName);

        return `You drank a bottle of ${wineName}.`;
    }

    cellarRevision(wineType){
        if(wineType){
            const wine = this.wines.find(w => w.wineType == wineType);
            if(wine){
                return `${wine.wineName} > ${wine.wineType} - ${wine.paid ? 'Has Paid' : 'Not Paid'}.`;
            } else{
                return `There is no ${wineType} in the cellar.`;
            }
           
        }else{
            let result = `You have space for ${this.space} bottles more.\n`;
            result += `You paid ${this.bill}$ for the wine.\n`;

            const sortedwines = this.wines.sort((a,b) => a.wineName.localeCompare(b.wineName));

            for (const wine of sortedwines) {
                result += `${wine.wineName} > ${wine.wineType} - ${wine.paid ? 'Has Paid' : 'Not Paid'}.\n`;
            }

            return result.trim();
        }

    }

}

// --  1  ---
// const selection = new WineSelection(2)
// console.log(selection.reserveABottle('Sauvignon Blanc Marlborough', 'White', 50));
// console.log(selection.reserveABottle('Cabernet Sauvignon Napa Valley', 'Red', 120));
// console.log(selection.reserveABottle('Bodegas Godelia Mencía', 'Rose', 144));

//  ---  2  ---
// const selection = new WineSelection(2)
// selection.reserveABottle('Sauvignon Blanc Marlborough', 'White',50);
// console.log(selection.payWineBottle('Sauvignon Blanc Marlborough', 120));
// console.log(selection.payWineBottle('Bodegas Godelia Mencía', 144));

//  ---  3  ---
const selection = new WineSelection(2)
selection.reserveABottle('Sauvignon Blanc Marlborough', 'White', 50);
selection.reserveABottle('Cabernet Sauvignon Napa Valley', 'Red', 120);
selection.payWineBottle('Sauvignon Blanc Marlborough', 50);
console.log(selection.openBottle('Sauvignon Blanc Marlborough'));
console.log(selection.openBottle('Cabernet Sauvignon Napa Valley'));

//  ---  4  ---
// const selection = new WineSelection(2)
// console.log(selection.reserveABottle('Bodegas Godelia Mencía', 'Rose', 144)); 
// console.log(selection.cellarRevision('Rose'));

//  ---  5  ---
// const selection = new WineSelection(5)
// selection.reserveABottle('Bodegas Godelia Mencía', 'Rose', 144);
// selection.payWineBottle('Bodegas Godelia Mencía', 144);
// selection.reserveABottle('Sauvignon Blanc Marlborough', 'White', 50);
// selection.reserveABottle('Cabernet Sauvignon Napa Valley', 'Red', 120);
// console.log(selection.cellarRevision());
