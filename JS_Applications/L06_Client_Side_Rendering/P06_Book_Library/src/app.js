import { html, render } from  '../node_modules/lit-html/lit-html.js';
import { dataService } from './services/dataService.js';
import { onLoadView } from './views/onLoadView.js';

const bodyEl = document.querySelector('body');
const loadAllBtn = document.getElementById('loadBooks');
loadAllBtn.addEventListener('click', onLoadAll);

onLoad();
function onLoad(){
    render(onLoadView(), bodyEl);
}

// function onLoadAll(){
//     const data = dataService.getAllBooks();

// }
