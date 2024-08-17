import { getAllMotorcyclesByModel } from '../data/motorcycles .js';
import { html, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';

const searchTemplate = (motorcycles, onSearch) => html`
    <section id="search">
        <div class="form">
            <h4>Search</h4>
            <form class="search-form" @submit=${onSearch}>
                <input type="text" name="search" id="search-input" />
                <button class="button-list">Search</button>
            </form>
        </div>
        <h4 id="result-heading">Results:</h4>
        <div class="search-result">
            ${motorcycles.length ? motorcycles.map(motorcycleTemplate) : html`
            <h2 class="no-avaliable">No result.</h2>`}
            <!--If there are matches display a div with information about every motorcycle-->
        </div>
    </section>
`;

//     model, imageUrl, year, mileage, contact, about

const motorcycleTemplate = (motorcycle) =>html`
    <div class="motorcycle">
        <img src=${motorcycle.imageUrl} alt="example1" />
        <h3 class="model">${motorcycle.model}</h3>
        <a class="details-btn" href="/details/${motorcycle._id}">More Info</a>
    </div>
`;

export async function showSearchCatalog(motorcycles){
    render(searchTemplate(motorcycles, createSubmitHandler(onSearch)));
}

async function onSearch(data, form){
    const {search}= data;
    if(!search){
        return alert('Field is required!');
    }
    const motorcycles = await getAllMotorcyclesByModel(search);
    showSearchCatalog(motorcycles);
}


