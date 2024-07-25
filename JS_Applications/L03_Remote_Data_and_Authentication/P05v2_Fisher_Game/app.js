document.querySelector('a[id="home"]').classList.add('active');
document.getElementById('logout').addEventListener('click', onLogout);
document.querySelector('.load').addEventListener('click', onLoadCatch)
document.getElementById('addForm').addEventListener('submit', onCreate);

const userNavRef = document.getElementById('user');
const guestNavRef = document.getElementById('guest');
const addBtnRef = document.querySelector('.add');
const catchesContainerRef = document.getElementById('catches');

const endpoints = {
    logout: 'http://localhost:3030/users/logout',
    catches: 'http://localhost:3030/data/catches',
}

let userData = JSON.parse(sessionStorage.getItem('userData'));

function hasOwner(id){
    return userData?._id === id;
}

updateNav();
function updateNav() {
    if (userData) {
        document.querySelector('nav p span').textContent = userData.email;
        userNavRef.style.display = 'inline-block';
        guestNavRef.style.display = 'none';
        addBtnRef.disabled = false;
        // document.querySelector('a[id="login"]').style.display = 'none';
        // document.querySelector('a[id="register"]').style.display = 'none';
        // document.querySelector('a[id="logout"]').style.display = 'inline-block';
    } else {
        document.querySelector('nav p span').textContent = 'guest';
        userNavRef.style.display = 'none';
        guestNavRef.style.display = 'inline-block';
        addBtnRef.disabled = true;
        // document.querySelector('a[id="login"]').style.display = 'inline-block';
        // document.querySelector('a[id="register"]').style.display = 'inline-block';
        // document.querySelector('a[id="logout"]').style.display = 'none';
    }
}


async function onLoadCatch(){
    const response = await fetch(endpoints.catches);
    const data = await response.json(); 
    catchesContainerRef.replaceChildren();

    data.forEach(x => {
        let div = listCatches(x);
        catchesContainerRef.appendChild(div);
    });
}



function listCatches(data){
    let isOwner = hasOwner(data._ownerId);
    let div = document.createElement('div');
    div.classList.add('catch');

    div.innerHTML += `<label>Angler</label>`
    div.innerHTML += `<input type="text" class="angler" ${isOwner ? "" : "disabled"} value="${data.angler}"></input>`
    div.innerHTML += `<label>Weight</label>`
    div.innerHTML += `<input type="number" class="weight" ${isOwner ? "" : "disabled"} value="${data.weight}"></input>`
    div.innerHTML += `<label>Species</label>`
    div.innerHTML += `<input type="text" class="species" ${isOwner ? "" : "disabled"} value="${data.species}"></input>`
    div.innerHTML += `<label>Location</label>`
    div.innerHTML += `<input type="text" class="location" ${isOwner ? "" : "disabled"} value="${data.location}"></input>`
    div.innerHTML += `<label>Bait</label>`
    div.innerHTML += `<input type="text" class="bait" ${isOwner ? "" : "disabled"} value="${data.bait}"></input>`
    div.innerHTML += `<label>Capture Time</label>`
    div.innerHTML += `<input type="number" class="captureTime" ${isOwner ? "" : "disabled"} value="${data.captureTime}"></input>`
    
    const updateBtn = document.createElement('button');
    updateBtn.classList.add('update');
    updateBtn.dataset.id = data._id;
    updateBtn.textContent = 'Update';

    const deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete');
    deleteBtn.dataset.id = data._id;
    deleteBtn.textContent = 'Delete';

    if(!hasOwner(data._ownerId)){
        updateBtn.disabled = true;
        deleteBtn.disabled = true;
    }

    div.appendChild(updateBtn);
    div.appendChild(deleteBtn);

    updateBtn.addEventListener('click', onUpdate);
    deleteBtn.addEventListener('click', onDelete);

    return div;
}

async function onLogout(e) {
    let option = {
        method: 'GET',
        headers: {
            'X-Authorization': userData.accessToken
        }
    }
    await fetch(endpoints.logout, option);
    sessionStorage.clear();
    userData = null;
    await onLoadCatch();
    updateNav();
}

async function onCreate(e){
    e.preventDefault(); 

    let formData = new FormData(e.target);
    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');
    let _ownerId = userData._id;
   
    if(!angler || !weight || !species || !location || !bait || !captureTime){
        return;  //  TODO  ERROR STATE
    }

    let data = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
        _ownerId
    }

    const options = createOption('POST', data);

    await fetch(endpoints.catches, options);
    onLoadCatch();
}

async function onUpdate(e){
    e.preventDefault(); 
    const id = e.target.dataset.id;

    const updateParentEl = e.target.parentNode;

    const [anglerEl, weightEl, speciesEl, locationEl, baitEl, captureTimeEl] = updateParentEl.querySelectorAll('input');

    let angler = anglerEl.value;
    let weight = weightEl.value;
    let species = speciesEl.value;
    let location =locationEl.value;
    let bait = baitEl.value;
    let captureTime = captureTimeEl.value;
    let _ownerId = userData._id;
   
    if(!angler || !weight || !species || !location || !bait || !captureTime){
        return;  //  TODO  ERROR STATE
        //throw new Error('All fields are required!')
    }

    if(isNaN(weight) || isNaN(captureTime)){
        alert('Value must be a number');
    }

    let data = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
        _ownerId
    }

    const options = createOption('PUT', data);

    await fetch(endpoints.catches + '/' + id, options);
    onLoadCatch();
}

async function onDelete(e){
    const id = e.target.dataset.id;
    const option = {
        method: 'DELETE',
        headers: {
            'X-Authorization': userData.accessToken
        }
    }

    await fetch(endpoints.catches + '/' + id, option);

    onLoadCatch();
} 
 
function createOption (method, data){
    return{
        method,
        headers: {
            'Content-type': 'application-json',
            'X-Authorization': userData.accessToken
        },
        body: JSON.stringify(data)  
    }
}