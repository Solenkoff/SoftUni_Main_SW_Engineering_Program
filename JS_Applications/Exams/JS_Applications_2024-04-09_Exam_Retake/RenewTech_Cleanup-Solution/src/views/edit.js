import { getSolutionById, updateSolution } from '../data/solutions.js';
import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';

const editTemplate = ( solution, onEdit ) => html`
    <section id="edit">
        <div class="form">
            <img class="border" src="./images/border.png" alt="" />
            <h2>Edit Solution</h2>
            <form class="edit-form" @submit=${onEdit}>
                <input 
                    type="text" 
                    name="type" 
                    id="type" 
                    placeholder="Solution Type"
                    .value=${solution.type} 
                />
                <input 
                    type="text" 
                    name="image-url" 
                    id="image-url" 
                    placeholder="Image URL" 
                    .value=${solution.imageUrl} 
                />
                <textarea 
                    id="description" 
                    name="description" 
                    placeholder="Description" 
                    rows="2"
                    cols="10"
                    .value=${solution.description} 
                ></textarea>
                <textarea 
                    id="more-info" 
                    name="more-info" 
                    placeholder="more Info" 
                    rows="2" cols="10"
                    .value=${solution.learnMore} 
                ></textarea>
                <button type="submit">Edit</button>
            </form>
        </div>
    </section>
`;


export async function showEdit(ctx){
    const id = ctx.params.id;
    const solution = await getSolutionById(id);
    
    render(editTemplate(solution, createSubmitHandler(onEdit)));
    
    async function onEdit(data, form){
        if(!data['type'] || !data['image-url'] || !data['description'] || !data['more-info']){
            return alert('All fields are required!');
        }
    
        const solutionData = {
            type: data['type'],
            imageUrl: data['image-url'],
            description: data['description'],
            learnMore: data['more-info']
        };

        await updateSolution(id, solutionData);
        page.redirect('/details/' + id);
    }
}

