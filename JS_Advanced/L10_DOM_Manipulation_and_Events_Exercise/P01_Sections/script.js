function create(inputText) {

   const contentEl = document.getElementById('content');
   let words = inputText;

   words.forEach(word => {
      const divElement = document.createElement('div');

      const pElement = document.createElement('p');
      pElement.style.display = 'none';
      pElement.textContent = word;
      
      divElement.appendChild(pElement);

      divElement.addEventListener('click', showP);
      contentEl.appendChild(divElement);
   });

   function showP(e){
      e.target.children[0].style.display = 'inline';
   }

}