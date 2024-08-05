import { html, render } from '../node_modules/lit-html/lit-html.js';
import { dataService } from './services/dataService.js';

const tbodyRoot = document.querySelector('tbody');
const searchFieldEl = document.getElementById('searchField');
const searchBtn = document.getElementById('searchBtn');
searchBtn.addEventListener('click', onSearchClick);
onLoad();

async function onLoad(){

    const data = await dataService.getAll();
    const viewTemp = Object.values(data).map(item => itemTemp(item));
    update(viewTemp);
}

function update(data){
    render(data, tbodyRoot);
}

function onSearchClick(){
    const pattern = searchFieldEl.value;
    const allTableRows = tbodyRoot.querySelectorAll('tr');
    allTableRows.forEach(tr => {
        console.log(typeof(tr));
        console.log(tr);
        tr.className = '';
        if(Object.values(tr.children).some(td => td.textContent.toLowerCase().includes(pattern.toLowerCase()))){
            tr.className = 'select';
        }
    });
    searchFieldEl.value = '';
}

function itemTemp(item){
    return html`
        <tr>
            <td>${item.firstName} ${item.lastName}</td>
            <td>${item.email}</td>
            <td>${item.course}</td>
        </tr>
    `
}