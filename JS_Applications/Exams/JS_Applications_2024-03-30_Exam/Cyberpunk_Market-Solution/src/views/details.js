import { html, page, render } from '../lib.js';
import { deleteItem, getItemById } from '../data/items.js';
import { createSubmitHandler, getUserData} from '../util.js';


const detailsTemplate = (data, isOwner, onDelete) => html`
    <section id="details">
        <div id="details-wrapper">
            <div>
                <img id="details-img" src=${data.imageUrl} alt="example1" />
                <p id="details-title">${data.item}</p>
            </div>
            <div id="info-wrapper">
                <div id="details-description">
                    <p class="details-price">Price: €${data.price}</p>
                    <p class="details-availability">${data.availability}</p>
                    <p class="type">Type: ${data.type}</p>
                    <p id="item-description">${data.description}</p>
                </div>
              <!--Edit and Delete are only for creator-->
              ${isOwner ? html`
                    <div id="action-buttons">
                        <a href="/edit/${data._id}" id="edit-btn">Edit</a>
                        <a href="javascript:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>
                    </div>
                ` : null}
            </div>
        </div>
    </section>
`;

//   item, imageUrl, price, availability, type, description
export async function showDetails(ctx){
    const id = ctx.params.id;

    const user = getUserData();
    const data = await getItemById(id);
    const itemOwner = data._ownerId;

    const isOwner = !!user && user._id == itemOwner;

    render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete (){
        const isConfirmedDelete = window.confirm('Do you really want to delete this item?');

        if(isConfirmedDelete){
            await deleteItem(id);
            page.redirect('/catalog');
        }
    }
}

