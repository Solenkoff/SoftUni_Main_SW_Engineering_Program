import { html, page, render } from '../lib.js';
import { getUserData } from '../util.js';
import { deleteFunFact, getFunFactById } from '../data/funFacts.js';
import { getSingleUserLikes, getTotalLikes, likeFunFact } from '../data/like.js';

//    category, imageUrl, description, moreInfo

const detailsTemplate = (data, isUser, isOwner, likesCount, hasUserLiked, onDelete, onLike) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src=${data.imageUrl} alt="example1" />
            <p id="details-category">${data.category}</p>
            <div id="info-wrapper">
                <div id="details-description">
                  <p id="description">${data.description}</p>
                  <p id ="more-info">${data.moreInfo}</p>
                </div>
                <h3>Likes:<span id="likes">${likesCount}</span></h3>
            <!--Edit and Delete are only for creator-->
                <div id="action-buttons">
                    ${isOwner ? html`               
                        <a href="/edit/${data._id}" id="edit-btn">Edit</a>
                        <a href="javascript:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>` : ( hasUserLiked == 0 ? html`
                        <a href="javascript:void(0)" id="like-btn" @click=${onLike}>Like</a>` : null)}
            <!--Bonus - Only for logged-in users ( not authors )-->
                </div>
            </div>
        </div>
    </section>
`;

// ${isUser ? html`   -->  Line 21
// </div>` : null}    -->  Line 27

export async function showDetails(ctx) {

    const id = ctx.params.id;

    const requests = [
        getFunFactById(id),
        getTotalLikes(id)
    ];


    const user = getUserData();
    if (user) {
        requests.push(getSingleUserLikes(id, user._id));
    }

    const [data, likesCount, hasUserLiked] = await Promise.all(requests);


    const isUser = !!user;
    const isOwner = !!user && user._id == data._ownerId;

    render(detailsTemplate(data, isUser, isOwner, likesCount, hasUserLiked, onDelete, onLike));

    async function onDelete() {
        const isConfirmedDelete = window.confirm('Do you really want to delete this fun fact?');

        if (isConfirmedDelete) {
            await deleteFunFact(id);
            page.redirect('/catalog');
        }
    }

    async function onLike() {
        await likeFunFact(id);
        page.redirect('/details/' + id);
    }
}


//  _id	"5af21925-526a-458e-b32d-1e1b368c30fd"
//  accessToken	"8d2d6f4a8f823e4ff53186b4784be548bb460425c94f8282297af4d2d8c05fe0
//  _ownerId	"5af21925-526a-458e-b32d-1e1b368c30fd"
//  _id	"8813ab5b-4dff-4ec3-8c84-6a79a2bbea13"