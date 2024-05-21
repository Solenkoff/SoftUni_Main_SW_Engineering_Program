function generateReport() {
    const outputEl = document.getElementById('output');
    const allRows = Array.from(document.querySelectorAll('tbody tr'));

    const outputArr = [];

    let checkOptions = {};

    const checkElements = Array.from(document.querySelectorAll('thead input'));
    for(let i = 0; i < checkElements.length; i++){
        checkOptions[checkElements[i].name] = i + 1;
    }
    
    const checked = Array
        .from(document.querySelectorAll('input[type="checkbox"]'))
        .filter(el => el.checked == true);

    allRows.forEach(row => {
        let tds = {};
        for (let i = 0; i < checked.length; i++) {
            let tdName = `${checked[i].name}`;
            let td = row.querySelector(`td:nth-of-type(${checkOptions[`${tdName}`]})`);
            tds[`${tdName}`] = td.textContent;
        }

        outputArr.push(tds);
    })

    outputEl.value = JSON.stringify(outputArr, null, 2);

}