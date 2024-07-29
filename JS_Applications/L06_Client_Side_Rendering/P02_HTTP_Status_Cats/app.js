import { render, html } from './node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const root = document.getElementById('allCats');

render(createCatList(cats), root);

function createCatList(catsData){
    return html`
        <ul>
            ${catsData.map(cat => createCatCard(cat))}
       </ul>
    `
}


function createCatCard(catData) {
    return html`
        <li>
            <img src="./images/${catData.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button @click="${toggleCatStatus}" class="showBtn">Show status code</button>
                <div class="status" style="display: none" id=${catData.id}>
                    <h4>Status Code: ${catData.statusCode}</h4>
                    <p>${catData.statusMessage}</p>
                </div>
            </div>
        </li> 
    `
}


function toggleCatStatus(e){
     const container = e.target.parentElement.querySelector('div');
     let currentState = container.style.display;

     if(currentState == 'none'){
        container.style.display = 'block';
        e.target.textContent = 'Hide status code';
     }else{
        container.style.display = 'none';
        e.target.textContent = 'Show status code';
     }

}