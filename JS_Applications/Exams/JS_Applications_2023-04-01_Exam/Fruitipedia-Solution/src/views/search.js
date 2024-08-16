import { getAllFruitsByName } from '../data/fruits.js';
import { html, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';

const searchTemplate = (fruits, onSearch) => html`
    <section id="search">
        <div class="form">
            <h2>Search</h2>
            <form class="search-form" @submit=${onSearch}>
                <input type="text" name="search" id="search-input" />
                <button class="button-list">Search</button>
            </form>
        </div>
        <h4>Results:</h4>
        <div class="search-result">
            ${fruits.length ? fruits.map(fruitTemplate) : html`
            <p class="no-result">No result.</p>`}
            <!--If there are matches display a div with information about every fruit-->
        </div>
    </section>
`;

//    name, imageUrl, description, nutrition

const fruitTemplate = (fruit) =>html`
    <div class="fruit">
        <img src=${fruit.imageUrl} alt="example1" />
        <h3 class="title">${fruit.name}</h3>
        <p class="description">${fruit.description}</p>
        <a class="details-btn" href="/details/${fruit._id}">More Info</a>
    </div>
`;

export async function showSearchCatalog(fruits){
    render(searchTemplate(fruits, createSubmitHandler(onSearch)));
}

async function onSearch(data, form){
    const {search}= data;
    if(!search){
        return alert('Field is required!');
    }
    const fruits = await getAllFruitsByName(search);
    showSearchCatalog(fruits);
}


