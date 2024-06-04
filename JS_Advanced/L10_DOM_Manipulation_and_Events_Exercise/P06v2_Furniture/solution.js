function solve() {

    const textAreaElements = Array.from(document.querySelectorAll('textarea'));
    const buttonElements = Array.from(document.querySelectorAll('button'));

    const incomingTextarea = textAreaElements[0];
    const outputTextarea = textAreaElements[1];

    const generateBtn = buttonElements[0];
    generateBtn.addEventListener('click', generate);

    const buyBtn = buttonElements[1];
    buyBtn.addEventListener('click', buy);

    const tbodyEl = document.querySelector('tbody');

    function buy() {

        let boughtFurn = [];
        let totalSpent = 0;
        let decFactorSum = 0;

        const checkedEls = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'));
           // .filter(x => x.disabled == false);

        checkedEls.forEach(element => {
            const rowData = Array.from(element.parentElement.parentElement.children);
            const name = rowData[1].children[0].textContent;
            const price = Number(rowData[2].children[0].textContent);
            const decFactor = Number(rowData[3].children[0].textContent);

            boughtFurn.push(name);
            totalSpent += price;
            decFactorSum += decFactor;
        });

        avgDecFactor = decFactorSum / boughtFurn.length;

        let result = `Bought furniture: ${boughtFurn.join(', ')}\n`;
        result += `Total price: ${totalSpent.toFixed(2)}\n`;
        result += `Average decoration factor: ${avgDecFactor}`;

        outputTextarea.textContent = result;
    }

    function generate() {
        const furnitureList = JSON.parse(incomingTextarea.value);

        furnitureList.forEach(element => {
            const trEl = document.createElement('tr');

            const imgTdEl = document.createElement('td');
            const nameTdEl = document.createElement('td');
            const priceTdEl = document.createElement('td');
            const decFactorTdEl = document.createElement('td');
            const checkboxTdEl = document.createElement('td');

            const imgEl = document.createElement('img');
            const nameEl = document.createElement('p');
            const priceEl = document.createElement('p');
            const decFactorEl = document.createElement('p');
            const checkboxEl = document.createElement('input');

            imgEl.src = element['img'];
            nameEl.textContent = element['name'];
            priceEl.textContent = element['price'];
            decFactorEl.textContent = element['decFactor'];
            checkboxEl.type = 'checkbox';

            imgTdEl.appendChild(imgEl);
            nameTdEl.appendChild(nameEl);
            priceTdEl.appendChild(priceEl);
            decFactorTdEl.appendChild(decFactorEl);
            checkboxTdEl.appendChild(checkboxEl);

            trEl.appendChild(imgTdEl);
            trEl.appendChild(nameTdEl);
            trEl.appendChild(priceTdEl);
            trEl.appendChild(decFactorTdEl);
            trEl.appendChild(checkboxTdEl);

            tbodyEl.appendChild(trEl);
        });

    }

}

