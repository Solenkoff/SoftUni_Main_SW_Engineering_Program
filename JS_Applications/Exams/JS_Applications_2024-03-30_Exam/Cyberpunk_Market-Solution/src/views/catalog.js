import { getAllItems } from '../data/items.js';
import { html, render } from '../lib.js';

const catalogTemplate = (items) => html`
    <h3 class="heading">Market</h3>
    <section id="dashboard">
          ${items.length ? items.map(itemTemplate) : html`
          <h3 class="empty">No Items Yet</h3>`}
    </section>
        <!-- Display an h2 if there are no posts -->
`;

//     item, imageUrl, price, availability, type, description
//    <h3 class="empty">No Items Yet</h3>    ==>  <!-- Display an h2 if there are no posts -->

const itemTemplate = (item) =>html`
    <div class="item">
        <img src=${item.imageUrl} alt="example1" />
        <h3 class="model">${item.item}</h3>
        <div class="item-info">
            <p class="price">Price: €${item.price}</p>
            <p class="availability">${item.availability}</p>
            <p class="type">Type: ${item.type}</p>
        </div>
        <a class="details-btn" href="/details/${item._id}">Uncover More</a>
    </div>
`;

export async function showCatalog(ctx){
    const items = await getAllItems();
    // console.log(items);
    // debugger
    render(catalogTemplate(items));
}