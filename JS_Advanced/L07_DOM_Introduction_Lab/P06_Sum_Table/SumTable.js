function sumTable() {
    let orderElements = document.querySelectorAll('tr td:nth-of-type(2)');
   
    let sum  = Array.from(orderElements).reduce((a,x) => {
        let currValue = Number(x.textContent) || 0;
        return a + currValue;
    }, 0);

    let sumElement = document.getElementById('sum');
    sumElement.textContent = sum;
}

// function sumTable() {
//     const tdEls = Array.from(document.querySelectorAll('td:nth-child(2)'));
 
//     tdEls.pop();
//     const outputSum = tdEls.reduce((a, v) => a + Number(v.textContent), 0);
//     const sumEl = document.getElementById('sum');
//     sumEl.textContent = outputSum;
// }