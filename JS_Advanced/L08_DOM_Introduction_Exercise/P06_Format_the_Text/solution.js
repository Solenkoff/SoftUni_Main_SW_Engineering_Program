function solve() {
  
    let inputElement = document.getElementById('input');
    let arrOfSentences = inputElement.value.split('.').filter(x => x !== '');
    let outputElement = document.getElementById('output');

    while (arrOfSentences.length > 0) {
        let text = arrOfSentences.splice(0, 3).join('. ') + '.';
        let newP = document.createElement('p');
        newP.textContent = text;
        outputElement.appendChild(newP);
    }

}

