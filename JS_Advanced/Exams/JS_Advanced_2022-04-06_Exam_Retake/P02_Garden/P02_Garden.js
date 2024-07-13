class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable
        this.plants = [];
        this.storage = [];
    }



    addPlant(plantName, spaceRequired) {
        if (spaceRequired > this.spaceAvailable) {
            throw new Error('Not enough space in the garden.');
        }

        let newPlant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0,
        }

        this.spaceAvailable -= spaceRequired;

        this.plants.push(newPlant);

        return `The ${newPlant.plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(p => p.plantName == plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (plant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }
        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;
        plant.quantity += quantity;

        return quantity == 1
            ? `${quantity} ${plantName} has successfully ripened.`
            : `${quantity} ${plantName}s have successfully ripened.`

    }

    harvestPlant(plantName) {
        let plant = this.plants.find(p => p.plantName == plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (!plant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        let plantToStorage = {
            plantName,
            quantity: plant.quantity
        }

        this.spaceAvailable += plant.spaceRequired;
        let plantIndex = this.plants.indexOf(plant);
        this.plants.splice(plantIndex, 1);
        this.storage.push(plantToStorage);
        

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let report = [`The garden has ${this.spaceAvailable} free space left.`];
        let plantsInTheGgarden = this.plants.map(p => p.plantName).sort((a, b) => a.localeCompare(b));
        let plantsReport = `Plants in the garden: ${plantsInTheGgarden.join(', ')}`;
        report.push(plantsReport);

       // report.push(plantsInTheGgarden.join(', '));

        if (this.storage.length == 0) {
            report.push('Plants in storage: The storage is empty.');
            
        }else{
            let storageReport = this.storage.map(p => `${p.plantName} (${p.quantity})`);
            report.push(`Plants in storage: ${storageReport.join(', ')}`);
        }

        return report.join('\n');
    }


}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());




