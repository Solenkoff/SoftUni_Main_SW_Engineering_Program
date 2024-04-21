function extractText() {
    let ulElement = document.getElementById('items');
    let textAreaElement = document.getElementById('result');

    textAreaElement.textContent = ulElement.textContent;

    // const tArea = document.getElementById('result')
    // const textLines = document.querySelectorAll('#items li');

    // for (const line of textLines) {
    //     tArea.value += line.textContent + '\n';
    // }
}