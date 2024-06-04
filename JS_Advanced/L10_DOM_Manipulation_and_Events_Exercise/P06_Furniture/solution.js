function solve() {

  let generateBtn = document.getElementsByTagName('button')[0];
  generateBtn.addEventListener('click',onClickGenerate);

  let buyBtn = document.getElementsByTagName('button')[1];
  buyBtn.addEventListener('click',onClickBuy);

  function onClickGenerate(event) {

    let inputData = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    let tableElement = document.querySelector('.table tbody');

    for (const obj of inputData) {
      let trItemElement = document.createElement('tr');
      
      let img = document.createElement('td');
      img.innerHTML = '<img src ="' + obj.img + '"/>';
      trItemElement.appendChild(img);

      let name = document.createElement('td');
      name.textContent = `${obj.name}`;
      trItemElement.appendChild(name);

      let price = document.createElement('td');
      price.textContent = `${obj.price}`;
      trItemElement.appendChild(price);
      
      let decFactor = document.createElement('td');
      decFactor.textContent = `${obj.decFactor}`;
      trItemElement.appendChild(decFactor);

      let mark = document.createElement('td');
      mark.innerHTML = '<input type="checkbox" />';
      trItemElement.appendChild(mark);

      tableElement.appendChild(trItemElement);
    }
  }

  function onClickBuy(event) {
   
    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'));

    let names = [];
    let totalPrice = 0;
    let avgDecFactor = 0;

    for (const box of checkboxes) {
      let parent = box.parentNode.parentNode.getElementsByTagName('td');

     
        let name = parent[1].textContent;
        let price = Number(parent[2].textContent);
        let decFactor = Number(parent[3].textContent);

        names.push(name);
        totalPrice += price;
        avgDecFactor += decFactor;
      
    }

    let result = `Bought furniture: ${names.join(', ')}\n`;

    result += `Total price: ${totalPrice.toFixed(2)}\n`;

    result += `Average decoration factor: ${avgDecFactor / names.length}`;

    let ouput = document.getElementsByTagName('textarea')[1];

    ouput.textContent = result;

  }
}

 




