function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let input = document.getElementById('searchField');
   let rowElements = document.querySelectorAll('tbody tr');

   function onClick() {

      for (let row of rowElements) {
         row.classList.remove('select');
         if(input.value !== '' && row.innerHTML.includes(input.value)){
            row.className = 'select';
         }
      }

      input.value = '';

   }
}