import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const root = document.getElementById('towns');
const inputEl = document.getElementById('searchText');
const resultEl = document.getElementById('result');
const btn = document.querySelector('button');
btn.addEventListener('click', search);

update(null);

function search() {
    const pattern = inputEl.value;
    const matchedTowns = towns.filter(t => t.includes(pattern));
    update(matchedTowns);`4567876   
    ' `
    renderMatchCount(matchedTowns.length);
};

function renderMatchCount(count){
    render(html`${count} matches found`, resultEl);
}

function createTown(name, matchedTowns) {
    return html`
        <li class=${matchedTowns?.includes(name) ? 'active' : ''}>${name}</li>
    `
}

function createTownList(towns, matchedTowns) {
    return html`<ul>${towns.map(town => createTown(town, matchedTowns))}</ul>`
}

function update(matchedTowns) {
    render(createTownList(towns, matchedTowns), root);
}
