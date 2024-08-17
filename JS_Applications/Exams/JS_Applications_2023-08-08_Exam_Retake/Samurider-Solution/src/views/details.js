import { deleteMotorcycle, getMotorcycleById } from '../data/motorcycles .js';
import { html, page, render } from '../lib.js';
import { getUserData} from '../util.js';


const detailsTemplate = (data, isOwner, onDelete) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src=${data.imageUrl} alt="example1" />
            <p id="details-title">${data.model}</p>
            <div id="info-wrapper">
                <div id="details-description">
                    <p class="year">Year: ${data.year}</p>
                    <p class="mileage">Mileage: ${data.mileage} km.</p>
                    <p class="contact">Contact Number: ${data.contact}</p>
                    <p id = "motorcycle-description">${data.about}</p>
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

//    model, imageUrl, year, mileage, contact, about

export async function showDetails(ctx){
    const id = ctx.params.id;

    const user = getUserData();
    const data = await getMotorcycleById(id);
    const motorcycleOwner = data._ownerId;

    const isOwner = !!user && user._id == motorcycleOwner;

    render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete (){
        const isConfirmedDelete = window.confirm('Do you really want to delete this motorcycle?');

        if(isConfirmedDelete){
            await deleteMotorcycle(id);
            page.redirect('/catalog');
        }
    }
}

