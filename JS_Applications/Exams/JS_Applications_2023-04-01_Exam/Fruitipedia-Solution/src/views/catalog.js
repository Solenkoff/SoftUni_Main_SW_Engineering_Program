import { getAllFruits } from '../data/fruits.js';
import { html, render } from '../lib.js';

const catalogTemplate = (fruits) => html`
    <h2>Fruits</h2>
    <section id="dashboard">
        <!-- Display a div with information about every post (if any)-->
        ${fruits.length ? fruits.map(fruitTemplate) : html`
        <h2>No fruit info yet.</h2>`}
        <!-- Display an h2 if there are no posts -->
    </section>
`;

//     name, imageUrl, description, nutrition

const fruitTemplate = (fruit) =>html`
    <div class="fruit">
        <img src=${fruit.imageUrl} alt="example1" />
        <h3 class="title">${fruit.name}</h3>
        <p class="description">${fruit.description}</p>
        <a class="details-btn" href="/details/${fruit._id}">More Info</a>
    </div>
`;

export async function showCatalog(ctx){
    const fruits = await getAllFruits();
    
    render(catalogTemplate(fruits));
}