function createSortedList(){
    const listOfNums = [];

    const list = {
        add,
        remove,
        get,
        size: listOfNums.length
    }

    function isValidIndex(index){
        return index >= 0 || index < listOfNums.length;
    }

    function rearange(){
        listOfNums.sort((a,b) => a - b);
    }

    function add(num){
        listOfNums.push(num);
        rearange(listOfNums);
    }

    function remove(index){
        if(isValidIndex(index)){
            listOfNums.splice(index, 1);
            rearange(listOfNums);
        }
    }

    function get(index){
        if(isValidIndex(index)){
            return listOfNums[index];
        }
    }

    return list;
}


let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
