import { html } from  '../../node_modules/lit-html/lit-html.js';
import { addFormView } from './addFormView.js';

export function onLoadView(){
    return html`
    <button id="loadBooks">LOAD ALL BOOKS</button>
    ${addFormView()}
    `
}