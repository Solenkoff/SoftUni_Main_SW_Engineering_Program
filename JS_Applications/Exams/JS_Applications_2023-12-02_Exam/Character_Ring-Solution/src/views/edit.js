import { getCharacterById, updateCharacter } from '../data/characters.js';
import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';


const editTemplate = ( character, onEdit ) => html`
    <section id="edit">
        <div class="form">
            <img class="border" src="./images/border.png" alt="">
            <h2>Edit Character</h2>
            <form class="edit-form" @submit=${onEdit}>
                <input
                    type="text"
                    name="category"
                    id="category"
                    placeholder="Character Type"
                    .value=${character.category}
                />
                <input
                    type="text"
                    name="image-url"
                    id="image-url"
                    placeholder="Image URL"
                    .value=${character.imageUrl}
                />
                <textarea
                    id="description"
                    name="description"
                    placeholder="Description"
                    rows="2"
                    cols="10"
                    .value=${character.description}
                ></textarea>
                <textarea
                    id="additional-info"
                    name="additional-info"
                    placeholder="Additional Info"
                    rows="2"
                    cols="10"
                    .value=${character.moreInfo}
                ></textarea>
                <button type="submit">Edit</button>
            </form>
            <img class="border" src="./images/border.png" alt="">
        </div>
    </section>
`;

//     category, imageUrl, description, moreInfo

export async function showEdit(ctx){
    const id = ctx.params.id;
    const character = await getCharacterById(id);
    
    render(editTemplate(character, createSubmitHandler(onEdit)));

    async function onEdit(data, form){
        if(!data['category'] || !data['image-url']|| !data['description'] || !data['additional-info']){
            return alert('All fields are required!');
        }
    
        const characterData = {
            category: data['category'],
            imageUrl: data['image-url'],
            description: data['description'],
            moreInfo: data['additional-info']
        };

        await updateCharacter(id, characterData);
        page.redirect('/details/' + id);
    }
}

