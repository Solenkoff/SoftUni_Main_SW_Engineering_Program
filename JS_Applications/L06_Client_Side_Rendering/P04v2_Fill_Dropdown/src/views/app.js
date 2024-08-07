import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { dataService } from "../service/dataService.js";

const root = document.getElementById("menu");
document.querySelector("form").addEventListener("submit", addItem);

onLoad();
async function onLoad(){
    const data = await dataService.getAllOption();
    const option = Object.values(data).map(option => optionTemp(option))
    update(option);
}

const optionTemp = (data) => html`<option value=${data._id}>${data.text}</option>`


function update(data){ 
    render(data, root);
}

async function addItem(e) {
    e.preventDefault();
    const inputRef = document.getElementById("itemText");
    const text = inputRef.value;
    inputRef.value = "";
    await dataService.postNewOption({text});
    onLoad(); 
}



