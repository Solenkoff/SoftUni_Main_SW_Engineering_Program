import { deleteProduct, getProductById } from '../data/products.js';
import { buyProduct, getSingleUserBuys, getTotalBuys } from '../data/buy.js';
import { html, page, render } from '../lib.js';
import { getUserData } from '../util.js';


const detailsTemplate = (data, isUser, isOwner, buysCount, hasUserBought, onDelete, onBuy) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src=${data.imageUrl} alt="example1" />
            <p id="details-title">${data.name}</p>
            <p id="details-category">
                Category: <span id="categories">${data.category}</span>
            </p>
            <p id="details-price">
                Price: <span id="price-number">${data.price}</span>$
            </p>
            <div id="info-wrapper">
                <div id="details-description">
                    <h4>Bought: <span id="buys">${buysCount}</span> times.</h4>
                    <span>${data.description}</span>
                </div>
            </div>
            <!--Edit and Delete are only for creator-->
            <div id="action-buttons">
                ${isOwner ? html`
                <a href="/edit/${data._id}" id="edit-btn">Edit</a>
                <a href="javascript:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>` : (hasUserBought == 0 ? html`
                <a href="javascript:void(0)" id="buy-btn" @click=${onBuy}>Buy</a>` : null)}
            <!--Bonus - Only for logged-in users ( not authors )-->
            </div>
        </div>
    </section>
`;
//     name, imageUrl, category, description, price


export async function showDetails(ctx) {
    
    const id = ctx.params.id;

    const requests = [
        getProductById(id),
        getTotalBuys(id)
    ];


    const user = getUserData(); 
    if(user){
        requests.push(getSingleUserBuys(id, user._id));
    }

    const [data, buysCount, hasUserBought] = await Promise.all(requests);


    const isUser = !!user;
    const isOwner = !!user && user._id == data._ownerId;

    render(detailsTemplate(data, isUser, isOwner, buysCount, hasUserBought, onDelete, onBuy));

    async function onDelete() {
        const isConfirmedDelete = window.confirm('Do you really want to delete this product?');

        if (isConfirmedDelete) {
            await deleteProduct(id);
            page.redirect('/catalog');
        }
    }

    async function onBuy(){
        await buyProduct(id);
        page.redirect('/details/' + id);
    }
}

