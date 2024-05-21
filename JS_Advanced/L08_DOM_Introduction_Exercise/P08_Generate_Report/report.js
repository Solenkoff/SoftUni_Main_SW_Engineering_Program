function generateReport() {
    
    let columns = document.getElementsByTagName('input');
    let rows = document.querySelectorAll('tbody tr');
    let checkedColumns = [];
    let result = [];

   for (const row of rows) {
       let currRow = {};
       for (let i = 0; i < row.children.length; i++) {
          if(columns[i].checked){
              currRow[columns[i].name] = row.children[i].textContent;
          }          
       }
       result.push(currRow);
   }

  document.getElementById('output').value = JSON.stringify(result);   
    
}