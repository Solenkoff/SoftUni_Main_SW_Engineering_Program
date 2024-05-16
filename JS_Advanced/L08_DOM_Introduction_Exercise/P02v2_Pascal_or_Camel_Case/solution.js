function solve() {
    const inputText = document.querySelector('#text').value;
    const namingConvention = document.querySelector('#naming-convention').value;
    const resultElement = document.querySelector('#result');

    const resultText = convertText(inputText, namingConvention);
    resultElement.textContent = resultText;

    function convertText(input, convention) {
        const conventions = ['Camel Case', 'Pascal Case'];

        if (!conventions.includes(convention)) {
            return 'Error!';
        }

        let convertedText = input.split(' ')
            .map(x => x[0].toUpperCase() + x.substring(1).toLowerCase()).join('');

        if (convention == conventions[0]) {
            convertedText = convertedText.replace(convertedText[0], convertedText[0].toLowerCase())
        }

        return convertedText;
    }
}