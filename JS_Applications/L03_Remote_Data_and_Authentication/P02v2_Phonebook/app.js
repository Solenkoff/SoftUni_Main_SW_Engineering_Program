function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click', loadPhonebook);
    document.querySelector('#btnCreate').addEventListener('click', createContact);
}

attachEvents();

async function loadPhonebook() {
    const ul = document.querySelector('#phonebook');
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await response.json();

    ul.replaceChildren();

    Object.values(data)
        .map(createElement)
        .forEach((p) => ul.appendChild(p))
}

async function createContact() {
    const personEl = document.querySelector('#person');
    const phoneEl = document.querySelector('#phone');
    const person = personEl.value;
    const phone = phoneEl.value;

    if (person && phone) {
        const response = await fetch('http://localhost:3030/jsonstore/phonebook', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person, phone })
        });

        loadPhonebook();
    } else {
        return alert('All fileds are required!');
    }

    personEl.value = '';
    phoneEl.value = '';

}

function createElement({ person, phone, _id }) {
    const contact = document.createElement('li');
    contact.setAttribute('id', _id);
    contact.textContent = `${person}: ${phone}`;

    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', deleteContact);
    contact.append(deleteBtn);

    return contact;
}

async function deleteContact(event) {
    const id = event.target.parentNode.id;
    const url = `http://localhost:3030/jsonstore/phonebook/` + id

    const response = await fetch(url, {
        method: 'delete',
        headers: { 'Content-Type': 'application/json' },
    })

    event.target.parentNode.remove();
}