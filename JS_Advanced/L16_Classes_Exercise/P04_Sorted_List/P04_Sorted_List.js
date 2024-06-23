class List{

    constructor(){
        this.sortedNums = [];
        this.size = this.sortedNums.length;
    }


    add(num){
        this.sortedNums.push(num);k
        this.sortedNums.sort((a,b) => a - b);
        this.size = this.sortedNums.length;
    }

    remove(index){
        if(index < 0 || index >= this.sortedNums.length){
            throw new Error('Index argument is outside the length of the list');
        }
        this.sortedNums.splice(index, 1);
        this.size = this.sortedNums.length;
    }

    get(index){
        if(index < 0 || index >= this.sortedNums.length){
            throw new Error('Index argument is outside the length of the list');
        }
        return this.sortedNums[index];
    }

}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
