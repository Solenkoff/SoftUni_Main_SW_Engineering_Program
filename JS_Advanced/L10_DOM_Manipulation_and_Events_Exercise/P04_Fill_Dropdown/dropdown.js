function addItem() {
    const newText = document.getElementById('newItemText');
    const newValue = document.getElementById('newItemValue');
    const optionsContainer = document.getElementById('menu');

    const optionElement = document.createElement('option');
    optionElement.text = newText.value;
    optionElement.value = newValue.value;

    if(newText.value !== '' && newValue.value !== ''){
        optionsContainer.appendChild(optionElement);
    }
    
    newText.value = '';
    newValue.value = '';
}