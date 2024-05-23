function solve() {
    const convertToElement = document.querySelector('#selectMenuTo');
    convertToElement.appendChild(createOption('Binary'));
    convertToElement.appendChild(createOption('Hexadecimal'));

    document.querySelector('button').addEventListener('click', convertIt);

    function convertIt(){
        const inputNumber = Number(document.querySelector('#input').value);
        const convertTo = convertToElement.value;
        const resultElement = document.querySelector('#result');

        const convertor = {
            binary() {
                return (number) => number.toString(2);
            },
            hexadecimal() {
                return (number) => number.toString(16).toUpperCase();
            },
        }

        resultElement.value = convertor[convertTo]()(inputNumber);
    }

    function createOption(chosenOption){

        const optionElement = document.createElement('option');
        optionElement.value = chosenOption.replace(chosenOption[0], chosenOption[0].toLowerCase());
        optionElement.textContent = chosenOption;

        return optionElement;
    }    
}