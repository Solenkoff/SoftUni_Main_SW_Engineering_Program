function generateReport() {

    let checkedColumns = {};

    Array.from(document.querySelectorAll('thead tr th'))
        .forEach((column, index) => {
            if (column.querySelector('input').checked) {
                checkedColumns[index] = column.querySelector('input').name;;
            }
        });

    const resultElement = document.querySelector('#output');

    const infoToReport = Array
        .from(document.querySelectorAll('tbody tr'))
        .map(row => {
            let rowData = {};
            const rowChildren = Array.from(row.children);

            rowChildren.forEach((ch, index) => {
                if (checkedColumns.hasOwnProperty(index)) {
                    const key = checkedColumns[index];
                    rowData[key] = ch.textContent;
                }
            });

            return rowData;
        });

    resultElement.textContent = JSON.stringify(infoToReport, null, 2);
}