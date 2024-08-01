class VegetableStore{

    constructor(owner, location){
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }


    loadingVegetables (vegetables){
        let uniqAddedVegies = [];

        for(let vegetable of vegetables){
            let vegData = vegetable.split(' ');
            let type = vegData[0];
            let quantity = Number(vegData[1]);
            let price = Number(vegData[2]);

            let currVegetable = this.availableProducts.find(p => p.type == type);
            

            if(!uniqAddedVegies.some(v => v == type)){
                uniqAddedVegies.push(type);
            }

            if(currVegetable){
                currVegetable.quantity += quantity;

                if(price > currVegetable.price){
                    currVegetable.price = price;
                }
            }else{
                currVegetable = {
                    type,
                    quantity,
                    price,
                }

                this.availableProducts.push(currVegetable);
            }
        }

        return `Successfully added ${uniqAddedVegies.join(', ')}`;
        
    }

}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
 console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
