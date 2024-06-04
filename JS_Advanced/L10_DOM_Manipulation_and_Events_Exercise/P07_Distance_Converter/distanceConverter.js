function attachEventsListeners() {
    let [inputField, outputField] = document.querySelectorAll('input[type="text"]');

    let inputUnitsElement = document.querySelector('#inputUnits');
    let outputUnitsElement = document.querySelector('#outputUnits');
    let convertBtn = document.querySelector('#convert');

    convertBtn.addEventListener('click', convertion);

    function convertion() {

        let numToConvert = Number(inputField.value);
        let result = 0;

        switch (inputUnitsElement.value) {
            case 'km': numToConvert *= 1000; break;
            case 'm': numToConvert = numToConvert; break;
            case 'cm': numToConvert *= 0.01; break;
            case 'mm': numToConvert *= 0.001; break;
            case 'mi': numToConvert *= 1609.34; break;
            case 'yrd': numToConvert *= 0.9144; break;
            case 'ft': numToConvert *= 0.3048; break;
            case 'in': numToConvert *= 0.0254; break;
        }

        switch (outputUnitsElement.value) {
            case 'km': result = numToConvert / 1000; break;
            case 'm': result = numToConvert; break;
            case 'cm': result = numToConvert / 0.01; break;
            case 'mm': result = numToConvert / 0.001; break;
            case 'mi': result = numToConvert / 1609.34; break;
            case 'yrd': result = numToConvert / 0.9144; break;
            case 'ft': result = numToConvert / 0.3048; break;
            case 'in': result = numToConvert / 0.0254; break;
        }

        outputField.value = result;
    }
}