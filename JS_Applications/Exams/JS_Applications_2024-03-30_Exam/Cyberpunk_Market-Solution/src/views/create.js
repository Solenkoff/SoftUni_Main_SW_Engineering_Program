import { createItem } from '../data/items.js';
import { html, page, render } from '../lib.js';
import { createSubmitHandler, renderNotification} from '../util.js';


const createTemplate = ( onCreate ) => html`
    <section id="create">
        <div class="form form-item">
            <h2>Share Your item</h2>
            <form class="create-form" @submit=${onCreate}>
                <input type="text" name="item" id="item" placeholder="Item" />
                <input
                    type="text"
                    name="imageUrl"
                    id="item-image"
                    placeholder="Your item Image URL"
                />
                <input
                    type="text"
                    name="price"
                    id="price"
                    placeholder="Price in Euro"
                />
                <input
                    type="text"
                    name="availability"
                    id="availability"
                    placeholder="Availability Information"
                />
                <input
                    type="text"
                    name="type"
                    id="type"
                    placeholder="Item Type"
                />
                <textarea
                    id="description"
                    name="description"
                    placeholder="More About The Item"
                    rows="10"
                    cols="50"
                ></textarea>
                <button type="submit">Add</button>
            </form>
        </div>
    </section>
`;

//     item, imageUrl, price, availability, type, description

export function showCreate(ctx){
    render(createTemplate(createSubmitHandler(onCreate)));
}

async function onCreate({item, imageUrl, price, availability, type, description}, form){
    if(!item || !imageUrl || !price || !availability || !type || !description){
        //return alert('All fields are required!');
        renderNotification('All fields are required!');
        return;
    }

    await createItem(item, imageUrl, price, availability, type, description);
    page.redirect('/catalog');
}