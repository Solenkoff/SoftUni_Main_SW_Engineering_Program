import { html, render } from '../lib.js';
import { getAllProducts } from '../data/products.js';

const catalogTemplate = (products) => html`
    <h2>Products</h2>
    <section id="dashboard">
      <!-- Display a div with information about every post (if any)-->
        ${products.length ? products.map(productTemplate) : html`
        <h2>No products yet.</h2>`}
      <!-- Display an h2 if there are no posts -->
    </section>
`;

//     name, imageUrl, category, description, price

const productTemplate = (product) =>html`
    <div class="product">
        <img src=${product.imageUrl} alt="example1" />
        <p class="title">${product.name}</p>
        <p><strong>Price:</strong><span class="price">${product.price}</span>$</p>
        <a class="details-btn" href="/details/${product._id}">Details</a>
    </div>
`;


export async function showCatalog(ctx){
    const products = await getAllProducts();
    
    render(catalogTemplate(products));
}


//    Object { 
//    ​​
//       _createdOn: 1617194295480
//       ​​
//       _id: "136777f5-3277-42ad-b874-76d043b069cb"
//       ​​
//       _ownerId: "847ec027-f659-4086-8032-5173e2f9c93a"
//
//       name: "Lipstick"
//       ​​
//       imageUrl: "/images/product example 3.png"
//
//       category: "Decorative cosmetics, Makeup, Lips"
//       ​​
//       description: "Lipstick is a cosmetic product ..."
//       ​​
//       price: "16.99"
//       ​​
//    }