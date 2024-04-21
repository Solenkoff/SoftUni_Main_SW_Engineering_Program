function calc() {
    
    const firstNum = Number(document.getElementById('num1').value);
    const secondNum = Number(document.getElementById('num2').value);

    const sum = firstNum + secondNum;

    const resultElement = document.getElementById('sum');
    resultElement.value = sum.toString();

}
