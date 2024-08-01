window.addEventListener('load', solve);

function solve() {

    const firstNameEl = document.getElementById('first-name');
    const lastNameEl = document.getElementById('last-name');
    const pCountEl = document.getElementById('people-count');
    const fromDateEl = document.getElementById('from-date');
    const daysCouontEl = document.getElementById('days-count');

    const infoListEl = document.querySelector('.ticket-info-list');
    const confirmEl = document.querySelector('.confirm-ticket');

    const mainEl = document.getElementById('main');
    const bodyEl = document.getElementById('body');

    const nextBtn = document.getElementById('next-btn');
    nextBtn.addEventListener('click', onNextClick);

    function onNextClick(event) {
        event.preventDefault();

        if (firstNameEl.value == '' ||
            lastNameEl.value == '' ||
            pCountEl.value == '' ||
            fromDateEl.value == '' ||
            daysCouontEl.value == ''
        ) {
            return;
        }

        const firstName = firstNameEl.value;
        const lastName = lastNameEl.value;
        const pCount = Number(pCountEl.value);
        const fromDate = fromDateEl.value;
        const daysCouont = Number(daysCouontEl.value);

        // if ((new Date(dateIn)).getTime() >= (new Date(dateOut)).getTime()){      //  IF date to compare
        //     return;
        // }

        // firstNameEl.value = '';    
        // lastNameEl.value = '';
        // pCountEl.value = '';
        // fromDateEl.value = '';
        // daysCouontEl.value = '';

        nextBtn.parentElement.reset();    //  Clearing the fields form the Form(previous step)
        nextBtn.disabled = true;

        const result = createPreview(firstName, lastName, pCount, fromDate, daysCouont);
        infoListEl.appendChild(result);
    };

    function createSectionView(firstName, lastName, pCount, fromDate, daysCouont){
        const listEl = createEl('li');
        listEl.className = 'ticket';

        const articleEl = createEl('article');
        articleEl.appendChild(createEl('h3', `Name: ${firstName} ${lastName}`));
        articleEl.appendChild(createEl('p', `From date: ${fromDate}`));
        articleEl.appendChild(createEl('p', `For ${daysCouont} days`));
        articleEl.appendChild(createEl('p', `For ${pCount} people`));

        listEl.appendChild(articleEl);

        return listEl;
    }

    function createPreview(firstName, lastName, pCount, fromDate, daysCouont) {
        const listEl = createSectionView(firstName, lastName, pCount, fromDate, daysCouont);

        const editBtn = createEl('button', 'Edit');
        editBtn.className = 'edit-btn';
        editBtn.addEventListener('click', () => onEditClick(firstName, lastName, pCount, fromDate, daysCouont));

        const continueBtn = createEl('button', 'Continue');
        continueBtn.className = 'continue-btn';
        continueBtn.addEventListener('click', () => onContinueClick(firstName, lastName, pCount, fromDate, daysCouont));

        listEl.appendChild(editBtn);
        listEl.appendChild(continueBtn);

        return listEl;
    }

    function createConfirmation(firstName, lastName, pCount, fromDate, daysCouont) {
        const listEl = createSectionView(firstName, lastName, pCount, fromDate, daysCouont);

        const confirmBtn = createEl('button', 'Confirm');
        confirmBtn.className = 'confirm-btn';
        confirmBtn.addEventListener('click', onConfirmClick);

        const cancelBtn = createEl('button', 'Cancel');
        cancelBtn.className = 'cancel-btn';
        cancelBtn.addEventListener('click', onCancelClick);

        listEl.appendChild(confirmBtn);
        listEl.appendChild(cancelBtn);

        return listEl;
    }

    function onConfirmClick(){
        const thanksEl = createEl('h1', 'Thank you, have a nice day!');
        thanksEl.setAttribute('id', 'thank-you');       
        const backBtn = createEl('button', 'Back');    
        backBtn.setAttribute('id', 'back-btn');
        backBtn.addEventListener('click', onBackClick);

        mainEl.remove();
        bodyEl.appendChild(thanksEl);
        bodyEl.appendChild(backBtn);
    }

    function onCancelClick(){
        //Array.from(confirmEl.children).forEach(liElement => liElement.remove());
        confirmEl.children[0].remove();
        nextBtn.disabled = false;
    }

    function onBackClick(){
        window.location.reload()
    }

    function onEditClick(firstName, lastName, pCount, fromDate, daysCouont){

        firstNameEl.value = firstName;
        lastNameEl.value = lastName;
        pCountEl.value = pCount;
        fromDateEl.value = fromDate;
        daysCouontEl.value = daysCouont;

        nextBtn.disabled = false;
        infoListEl.textContent = '';

    }

    function onContinueClick(firstName, lastName, pCount, fromDate, daysCouont){
        const result = createConfirmation(firstName, lastName, pCount, fromDate, daysCouont);

        infoListEl.textContent = '';
        confirmEl.appendChild(result);
        
    }

    function createEl(type, content){
        const element = document.createElement(type);

        if(content){
            element.textContent = content;
        }

        return element;
    }
}




