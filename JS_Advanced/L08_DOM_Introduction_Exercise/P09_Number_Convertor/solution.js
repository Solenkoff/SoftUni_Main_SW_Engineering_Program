function solve() {
    document.querySelector("button").addEventListener("click", convertIt);
  
    let optionOne = document.createElement("option");
    optionOne.value = "binary";
    optionOne.innerHTML = "Binary";

    let optionTwo = document.createElement("option");
    optionTwo.value = "hexadecimal";
    optionTwo.innerHTML = "Hexadecimal";
    
    let convertToElement = document.getElementById("selectMenuTo");
    convertToElement.appendChild(optionOne);
    convertToElement.appendChild(optionTwo);

    let resultElement = document.getElementById("result");

    function convertIt() {

      let inputNumber = Number(document.getElementById("input").value);

      if (convertToElement.value === "binary") {    
        resultElement.value = inputNumber.toString(2);
      }else if(convertToElement.value === 'hexadecimal'){
        resultElement.value = inputNumber.toString(16).toString().toUpperCase();
      }

    }

  }