import { html } from '../app.js';
import { dataService } from '../service/dataService.js';
import { userHelper } from '../utility/userHelper.js';


export async function showDetailsView (ctx) {
    const itemId = ctx.params.id;
    const item = await dataService.getFurnitureDetails(itemId);
    const isOwner = userHelper.hasOwner(item._ownerId);
    if (item.img[0] == '.') {
        item.img = item.img.slice(1);
    }
    ctx.render(detailsTemplate(item, isOwner));
}

const detailsTemplate = (item, isOwner) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=${item.img} />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${item.make}</span></p>
        <p>Model: <span>${item.model}</span></p>
        <p>Year: <span>${item.year}</span></p>
        <p>Description: <span>${item.description}</span></p>
        <p>Price: <span>${item.price}</span></p>
        <p>Material: <span>${item.material}</span></p>
        ${isOwner? getButtons(item._id) : ''}
    </div>
</div>`;

function getButtons (id) {
    return html`
    <div>
        <a href=/edit/${id} class="btn btn-info">Edit</a>
        <a href=/delete/${id} class="btn btn-red">Delete</a>
    </div>`;
}