import { getFunFactById, updateFunFact } from '../data/funFacts.js';
import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';


const editTemplate = ( funFact, onEdit ) => html`
    <section id="edit">
        <div class="form">
            <h2>Edit Fact</h2>
            <form class="edit-form" @submit=${onEdit}>
                <input
                    type="text"
                    name="category"
                    id="category"
                    placeholder="Category"
                    .value=${funFact.category}
                />
                <input
                    type="text"
                    name="image-url"
                    id="image-url"
                    placeholder="Image URL"
                    .value=${funFact.imageUrl}
                />
                <textarea
                    id="description"
                    name="description"
                    placeholder="Description"
                    rows="10"
                    cols="50"
                    .value=${funFact.description}
                ></textarea>
                <textarea
                    id="additional-info"
                    name="additional-info"
                    placeholder="Additional Info"
                    rows="10"
                    cols="50"
                    .value=${funFact.moreInfo}
                ></textarea>
                <button type="submit">Post</button>
            </form>
        </div>
    </section>
`;

//     category, imageUrl, description, moreInfo

export async function showEdit(ctx){
    const id = ctx.params.id;
    const funFact = await getFunFactById(id);
    
    render(editTemplate(funFact, createSubmitHandler(onEdit)));

    async function onEdit(data, form){
        if(!data['category'] || !data['image-url']|| !data['description'] || !data['additional-info']){
            return alert('All fields are required!');
        }
    
        const funFactData = {
            category: data['category'],
            imageUrl: data['image-url'],
            description: data['description'],
            moreInfo: data['additional-info']
        };

        await updateFunFact(id, funFactData);
        page.redirect('/details/' + id);
    }
}

