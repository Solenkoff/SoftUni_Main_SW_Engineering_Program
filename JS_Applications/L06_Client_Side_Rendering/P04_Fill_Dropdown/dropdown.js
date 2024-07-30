import { html, render } from "../node_modules/lit-html/lit-html.js";

const url = "http://localhost:3030/jsonstore/advanced/dropdown";
document.querySelector("form").addEventListener("submit", addItem);
const root = document.getElementById("menu");

onLoad();
async function onLoad(){
    const response = await fetch (url);
    const data = await response.json();
    const option = Object.values(data).map(option => optionTemp(option))
    update(option);
}

const optionTemp = (data) => html`<option value=${data._id}>${data.text}</option>`


function update(data){ 
    render(data, root);
}

function addItem(e) {
    e.preventDefault();
    const inputRef = document.getElementById("itemText");
    const text = inputRef.value;
    inputRef.value = "";
    addItemDb({text});
}

async function addItemDb(data){
    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",        
        },
        body: JSON.stringify(data)
    });
    onLoad();
}

