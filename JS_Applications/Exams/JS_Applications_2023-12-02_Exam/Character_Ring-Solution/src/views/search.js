import { getAllCarsByModel } from '../data/cars.js';
import { html, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';

const searchTemplate = (cars, onSearch) => html`
    <section id="search">
        <div class="form">
            <h4>Search</h4>
            <form class="search-form" @submit=${onSearch}>
                <input type="text" name="search" id="search-input" />
                <button class="button-list">Search</button>
            </form>
        </div>
        <div class="search-result">
            ${cars.length ? cars.map(carTemplate) : html`
                <h2 class="no-avaliable">No result.</h2>
                <!--If there are matches display a div with information about every motorcycle-->
            `}
        </div>
    </section>
`;

//     model, imageUrl, price, weight, speed, about

const carTemplate = (car) =>html`
    <div class="car">
        <img src="${car.imageUrl}" alt="example1"/>
        <h3 class="model">${car.model}</h3>
        <a class="details-btn" href="/details/${car._id}">More Info</a>
    </div> 
`;

export async function showSearchCatalog(cars){
    render(searchTemplate(cars, createSubmitHandler(onSearch)));
}

async function onSearch(data, form){
    const {search}= data;
    if(!search){
        return alert('Field is required!');
    }
    const cars = await getAllCarsByModel(search);
    showSearchCatalog(cars);
}


