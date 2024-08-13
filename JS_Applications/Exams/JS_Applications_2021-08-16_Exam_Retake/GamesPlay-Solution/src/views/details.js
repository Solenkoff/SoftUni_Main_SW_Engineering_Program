import { addNewComment, getAllComments } from '../data/comment.js';
import { deleteGame, getGameById } from '../data/games.js';
import { html, page, render } from '../lib.js';
import { getUserData, createSubmitHandler } from '../util.js';


const detailsTemplate = (data, isUser, isOwner, comments, onDelete, onComment) => html`
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
            <div class="game-header">
                <img class="game-img" src=${data.imageUrl} />
                <h1>${data.title}</h1>
                <span class="levels">MaxLevel: ${data.maxLevel}</span>
                <p class="type">${data.category}</p>
            </div>
            <p class="text">${data.summary}</p>
            <!-- Bonus ( for Guests and Users ) -->
            <div class="details-comments">
                <h2>Comments:</h2>
                <ul>
                    <!-- list all comments for current game (If any) -->
                    ${comments.length ? comments.map(commentTemplate) : html`
                    <p class="no-comment">No comments.</p>`}
                </ul>
                <!-- Display paragraph: If there are no games in the database -->
                
            </div>
            <!-- Edit/Delete buttons ( Only for creator of this game )  -->
            ${isOwner ? html`
            <div class="buttons">
                <a href="/edit/${data._id}" class="button">Edit</a>
                <a href="javascript:void(0)" class="button" @click=${onDelete}>Delete</a>
            </div>
            ` : null}
        </div>
        <!-- Bonus -->
        <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
        ${isUser && !isOwner ? html`
        <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form" @submit=${onComment}>
                <textarea name="comment" placeholder="Comment......" id="clearTextarea"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>` : null}
    </section>
`;

const commentTemplate = (comment) => html`
    <li class="comment">
        <p>Content: ${comment.comment}</p>
    </li>
`;

//     title, category, maxLevel, imageUrl, summary

export async function showDetails(ctx) {
    
    const id = ctx.params.id;

    const requests = [
        getGameById(id),
        getAllComments(id)
    ];

    const [data, comments] = await Promise.all(requests);

    const user = getUserData(); 
    const isUser = !!user;
    const isOwner = !!user && user._id == data._ownerId;

    render(detailsTemplate(data, isUser, isOwner, comments, onDelete, createSubmitHandler(onComment)));

    async function onDelete() {
        const isConfirmedDelete = window.confirm('Do you really want to delete this game?');

        if (isConfirmedDelete) {
            await deleteGame(id);
            page.redirect('/');
        }
    }

    async function onComment({comment}, form){
        await addNewComment(id, comment);
        document.getElementById('clearTextarea').value = '';
        page.redirect('/details/' + id);
    }
  
}

