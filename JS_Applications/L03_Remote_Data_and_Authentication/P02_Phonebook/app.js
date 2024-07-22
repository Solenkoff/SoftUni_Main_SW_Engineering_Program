function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';
    const phonebookEl = document.getElementById('phonebook');

    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', onLoad);
    createBtn.addEventListener('click', onCreate);

    async function onLoad(e) {
        e.preventDefault();

        try {
            const response = await fetch(baseUrl);
            const data = await response.json();

            if (response.status != 200) {
                const error = await response.json();
                throw new Error(error.message);
            }

            renderPhonebook(Object.values(data));

        } catch (error) {
            alert(`Error: ${error.message}`);
        }
    }

    function renderPhonebook(phonebookData) {
        phonebookEl.replaceChildren();

        phonebookData.forEach(entry => {
            const liEl = document.createElement('li');
            //liEl.setAttribute('id', `${entry._id}`);

            liEl.textContent = `${entry.person}: ${entry.phone}`;
            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.dataset.id = entry._id;
            deleteBtn.addEventListener('click', onDelete);
            liEl.appendChild(deleteBtn);

            phonebookEl.appendChild(liEl);
        });

       
    }

    async function onCreate(e){
        e.preventDefault();

        const personEl = document.getElementById('person');
        const person = personEl.value;
        const phoneEl = document.getElementById('phone');
        const phone = phoneEl.value;

        try {
            const request = await fetch(baseUrl, {
                method: 'post',
                headers: {'Content-type': 'application.json'},
                body: JSON.stringify({person, phone})
            });

            if (!request.ok) {
                throw new Error('Function not available!');
            }

            personEl.value = '';
            phoneEl.value = '';

            onLoad(e);

        } catch (error) {
            alert(error.message);
        }
    }

    async function onDelete(e){

        const id = e.target.dataset.id;
        const url = `${baseUrl}/${id}`;

        const request = await fetch(url, {
            method: 'delete',
            headers: {'Content-type': 'application/json'}
        })

        e.target.parentNode.remove();
    }

}

attachEvents();