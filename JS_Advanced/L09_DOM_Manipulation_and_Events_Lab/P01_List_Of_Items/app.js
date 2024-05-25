function addItem() {
    let inputElement = document.getElementById('newItemText');
    let itemsElement = document.getElementById('items');

    if(inputElement.value.length == 0){
        return;
    }
    
    let liElement = document.createElement('li');
    liElement.textContent = inputElement.value;

    itemsElement.appendChild(liElement);

    inputElement.value = '';
}