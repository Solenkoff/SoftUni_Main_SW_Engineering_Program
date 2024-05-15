function subtract() {
    let firstNumElement = document.getElementById('firstNumber');
    let secondNumElement = document.getElementById('secondNumber');

    let firstNum = Number(firstNumElement.value);
    let secondNum = Number(secondNumElement.value);

    let subtraction = firstNum - secondNum;

    let resultElement = document.getElementById('result');
    resultElement.textContent = subtraction;
}