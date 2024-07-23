function solve(){

    const loadBtn = document.getElementById('loadBooks');
    loadBtn.addEventListener('click', loadAllBooks);

    const createBtn = document.querySelector('form button');
    createBtn.addEventListener('click', onCreate);


}

solve();

async function onCreate(e){
    e.preventDefault();

    const url = 'http://localhost:3030/jsonstore/collections/books';

    const formEl = document.querySelector('form');
    const formData = new FormData(formEl);
    const {author, title} = Object.fromEntries(formData);

    fetch(url, {
        method: 'post',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify({ author, title })
    });

    await loadAllBooks();
}

async function loadAllBooks(){

    const url = 'http://localhost:3030/jsonstore/collections/books';
    
    const tbodyEl = document.querySelector('tbody');
    tbodyEl.replaceChildren();

    try {
        const response = await fetch(url);
        const data = await response.json();
    
        Object.entries(data).forEach(([id, value]) => tbodyEl.appendChild(renderBook([id, value])));

    } catch (error) {
        alert(error.message);
    }
}

function renderBook([id, {author, title}]){
    const tRow = createEl('tr');
    const titleEl = createEl('td', title, tRow);
    const authorEl = createEl('td', author, tRow);
    const buttonsTdEl = createEl('td', undefined, tRow);
    const editBtn = createEl('button', 'Edit', buttonsTdEl);
    editBtn.dataset.id = id;
    const deleteBtn = createEl('button', 'Delete', buttonsTdEl);

    editBtn.addEventListener('click', onEdit);
    // deleteBtn.addEventListener('click', onDelete);

    return tRow;
}

async function onEdit(e){
    const id = e.target.dataset.id;
    document.querySelector('form h3').textContent = 'Edit FORM';
    const saveBtn = document.querySelector('form button');
    saveBtn.textContent = 'Save';
    saveBtn.addEventListener('click', saveChanges(id))
    
}

async function saveChanges(id){
    //e.preventDefault();

    const url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    const formEl = document.querySelector('form');
    const formData = new FormData(formEl);
    const {author, title} = Object.fromEntries(formData);

    fetch(url, {
        method: 'put',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify({ author, title })
    });

    loadAllBooks();
}

function createEl(type, content, appender){
    const el = document.createElement(type);

    if(content){
        el.textContent = content;
    }
    if(appender){
        appender.appendChild(el);
    }

    return el;
}