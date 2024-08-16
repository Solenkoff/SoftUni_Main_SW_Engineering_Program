import { deleteFruit, getFruitById } from '../data/fruits.js';
import { html, page, render } from '../lib.js';
import { getUserData} from '../util.js';


const detailsTemplate = (data, isOwner, onDelete) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src=${data.imageUrl} alt="example1" />
            <p id="details-title">${data.name}</p>
            <div id="info-wrapper">
                <div id="details-description">
                    <p>${data.description}</p>
                    <p id="nutrition">Nutrition</p>
                    <p id="details-nutrition">${data.nutrition}</p>
                </div>
                <!--Edit and Delete are only for creator-->
                ${isOwner ? html`
                <div id="action-buttons">
                    <a href="/edit/${data._id}" id="edit-btn">Edit</a>
                    <a href="javascript:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>
                </div>` : null}
            </div>
        </div>
    </section>
`;

//    name, imageUrl, description, nutrition

export async function showDetails(ctx){
    const id = ctx.params.id;

    const user = getUserData();
    const data = await getFruitById(id);
    const fruitOwner = data._ownerId;

    const isOwner = !!user && user._id == fruitOwner;

    render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete (){
        const isConfirmedDelete = window.confirm('Do you really want to delete this fruit?');

        if(isConfirmedDelete){
            await deleteFruit(id);
            page.redirect('/catalog');
        }
    }
}

