import { deleteSolution, getSolutionById } from '../data/solutions.js';
import { getSingleUserLikes, getTotalLikes, likeSolution } from '../data/like.js';
import { html, page, render } from '../lib.js';
import { getUserData } from '../util.js';


const detailsTemplate = (data, isUser, isOwner, likesCount, hasUserLiked, onDelete, onLike) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src=${data.imageUrl} alt="example1" />
            <div>
                <p id="details-type">${data.type} </p>
                <div id="info-wrapper">
                    <div id="details-description">
                        <p id="description">${data.description} </p>
                        <p id="more-info">${data.learnMore} </p>
                    </div>
                </div>
                <h3>Like Solution:<span id="like">${likesCount}</span></h3>
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


export async function showDetails(ctx) {
    
    const id = ctx.params.id;

    const requests = [
        getSolutionById(id),
        getTotalLikes(id)
    ];

    const user = getUserData(); 
    if(user){
        requests.push(getSingleUserLikes(id, user._id));
    }

    const [data, likesCount, hasUserLiked] = await Promise.all(requests);

    const isUser = !!user;
    const isOwner = !!user && user._id == data._ownerId;

    render(detailsTemplate(data, isUser, isOwner, likesCount, hasUserLiked, onDelete, onLike));

    async function onDelete() {
        const isConfirmedDelete = window.confirm('Do you really want to delete this solution?');

        if (isConfirmedDelete) {
            await deleteSolution(id);
            page.redirect('/catalog');
        }
    }

    async function onLike(){
        await likeSolution(id);
        page.redirect('/details/' + id);
    }
}

