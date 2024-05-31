function solve() {

   const textArea = document.querySelector('div.shopping-cart textarea');

   const buttonElements = Array.from(document.querySelectorAll('button.add-product'));
   buttonElements.forEach(element => {
       element.addEventListener('click', addProduct);
   });

   const checkoutBtn = document.querySelector('button.checkout');
   checkoutBtn.addEventListener('click', checkOut);

   let boughtProducts = [];
   let totalSpent = 0;

   function addProduct(e) {
       const productName = e.target.parentNode.parentNode
           .querySelector('div.product-title').textContent;
       const productPrice = Number(e.target.parentNode.parentNode
           .querySelector('div.product-line-price').textContent);

       if (!boughtProducts.some(p => p == productName)) {
           boughtProducts.push(productName);
       }

       totalSpent += productPrice;

       textArea.textContent = textArea
           .textContent + `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;

   }

   function checkOut(e){
       const message = `You bought ${boughtProducts.join(', ')} for ${totalSpent.toFixed(2)}.`;
       textArea.textContent = textArea.textContent + message;

       buttonElements.forEach(button => {
           button.disabled = true;
       });
       checkoutBtn.disabled = true;
   }

}