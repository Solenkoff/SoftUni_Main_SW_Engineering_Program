window.addEventListener("load", solve);

function solve() {
  let makeInputElement = document.getElementById('make');
  let modelInputElement = document.getElementById('model');
  let yearInputElement = document.getElementById('year');
  let fuelInputElement = document.getElementById('fuel');
  let originalCostInputElement = document.getElementById('original-cost');
  let sellingPriceInputElement = document.getElementById('selling-price');
  let publishButtonElement = document.getElementById('publish');
  let tableRowCarElement = document.getElementById('table-body');
  let soldCarsUlElement = document.getElementById('cars-list');
  let totalProfitElement = document.getElementById('profit');

  makeInputElement.value = 'Audi';
  modelInputElement.value = 'A4';
  originalCostInputElement.value = '10000';
  sellingPriceInputElement.value = '11900';

  publishButtonElement.addEventListener('click', (ev) => {
    ev.preventDefault();

    let make = makeInputElement.value;
    let model = modelInputElement.value;
    let year = yearInputElement.value;
    let fuel = fuelInputElement.value;
    let originalCost = Number(originalCostInputElement.value);
    let sellingPrice = Number(sellingPriceInputElement.value);

    makeInputElement.value = '';
    modelInputElement.value = '';
    originalCostInputElement.value = '';
    sellingPriceInputElement.value = '';

    if (!make || !model || !originalCost || !sellingPrice || (originalCost > sellingPrice)) {
      return;
    }

    let carTrElement = document.createElement('tr');
    carTrElement.classList.add('row');

    let makeTrElement = document.createElement('td');
    makeTrElement.textContent = make;
    let modelTrElement = document.createElement('td');
    modelTrElement.textContent = model;
    let yearTrElement = document.createElement('td');
    yearTrElement.textContent = year;
    let fuelTrElement = document.createElement('td');          
    fuelTrElement.textContent = fuel            
    let originalCostTrElement = document.createElement('td');
    originalCostTrElement.textContent = originalCost;
    let sellingPriceTrElement = document.createElement('td');
    sellingPriceTrElement.textContent = sellingPrice;
    let buttonsTdElement = document.createElement('td');

    let editButtonElement = document.createElement('button');
    editButtonElement.textContent = 'Edit';
    editButtonElement.classList.add('action-btn');
    //editButtonElement.setAttribute("id", "edit");
    editButtonElement.addEventListener('click', (ev) => {
      ev.preventDefault();

      makeInputElement.value = make;
      modelInputElement.value = model;
      yearInputElement.value = year;
      fuelInputElement.value = fuel;
      originalCostInputElement.value = originalCost;
      sellingPriceInputElement.value = sellingPrice;

      carTrElement.remove();
    });

    let sellButtonElement = document.createElement('button');
    sellButtonElement.textContent = 'Sell';
    sellButtonElement.classList.add('action-btn');
    // sellBtn.setAttribute("id", "sell");
    sellButtonElement.addEventListener('click', (ev) => {
      ev.preventDefault();

      let soldCarLiElement = document.createElement('li');
      soldCarLiElement.classList.add('each-list');
      let makeAndModelSpanElement = document.createElement('span');
      makeAndModelSpanElement.textContent = make + ' ' + model;
      let yearSpanElement = document.createElement('span');
      yearSpanElement.textContent = year;
      let profitSpanElement = document.createElement('span');
      profitSpanElement.textContent = sellingPrice - originalCost;

      soldCarLiElement.appendChild(makeAndModelSpanElement);
      soldCarLiElement.appendChild(yearSpanElement);
      soldCarLiElement.appendChild(profitSpanElement);

      soldCarsUlElement.appendChild(soldCarLiElement);
      carTrElement.remove();

      let profitSoFar = Number(totalProfitElement.textContent);
      totalProfitElement.textContent = (profitSoFar + Number(profitSpanElement.textContent)).toFixed(2);
    });

    buttonsTdElement.appendChild(editButtonElement);
    buttonsTdElement.appendChild(sellButtonElement);

    carTrElement.appendChild(makeTrElement);
    carTrElement.appendChild(modelTrElement);
    carTrElement.appendChild(yearTrElement);
    carTrElement.appendChild(fuelTrElement);
    carTrElement.appendChild(originalCostTrElement);
    carTrElement.appendChild(sellingPriceTrElement);
    carTrElement.appendChild(buttonsTdElement);

    tableRowCarElement.appendChild(carTrElement);
  })

}
