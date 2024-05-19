function search() {
   let townElements = Array.from(document.querySelectorAll('#towns li'));
   let inputText = document.getElementById('searchText').value;
   let resultElement = document.getElementById('result');
   let matches = 0;

   townElements.forEach(town => {
         if(town.textContent.includes(inputText)){
            town.style.fontWeight = 'bold';
            town.style.textDecoration = 'underline';
            matches++;
         }else{
            town.style.fontWeight = 'normal';
            town.style.textDecoration = 'none';
         }
   });

   inputText.value = '';
   resultElement.textContent = `${matches} matches found`;

}
