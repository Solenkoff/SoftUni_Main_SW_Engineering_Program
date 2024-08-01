window.addEventListener("load", solve);

function solve() {

    const snowmanNameEl = document.getElementById('snowman-name');
    const heightEl = document.getElementById('snowman-height');
    const locationEl = document.getElementById('location');
    const creatorNameEl = document.getElementById('creator-name');
    const attributeEl = document.getElementById('special-attribute');

    const previewEl = document.querySelector('.snowman-preview');
    const snowListEl = document.querySelector('.snow-list');

    const mainEl = document.getElementById('hero');
    const bodyEl = document.querySelector('.body');
    const imageEl = document.getElementById('back-img');

    const addBtn = document.querySelector('.add-btn');
    addBtn.addEventListener('click', onAddClick);

    function onAddClick(event) {
        event.preventDefault();

        if (snowmanNameEl.value == '' ||
            heightEl.value == '' ||
            locationEl.value == '' ||
            creatorNameEl.value == '' ||
            attributeEl.value == ''
        ) {
            return;
        }

        const snowmanName = snowmanNameEl.value;
        const height = heightEl.value;
        const location = locationEl.value;
        const creatorName = creatorNameEl.value;
        const attribute = attributeEl.value;

        addBtn.parentElement.reset();   
        addBtn.disabled = true;

        const result = createPreview(snowmanName, height, location, creatorName, attribute);
        previewEl.appendChild(result);
    };

    function createSectionView(snowmanName, height, location, creatorName, attribute){
        const listEl = createEl('li');

        const articleEl = createEl('article');
        articleEl.appendChild(createEl('p', `Name: ${snowmanName}`));
        articleEl.appendChild(createEl('p', `Height: ${height}`));
        articleEl.appendChild(createEl('p', `Location: ${location}`));
        articleEl.appendChild(createEl('p', `Creator: ${creatorName}`));
        articleEl.appendChild(createEl('p', `Attribute: ${attribute}`));

        listEl.appendChild(articleEl);

        return listEl;
    }

    function createPreview(snowmanName, height, location, creatorName, attribute) {
        const listEl = createSectionView(snowmanName, height, location, creatorName, attribute);
        listEl.className = 'snowman-info';

        const editBtn = createEl('button', 'Edit');
        editBtn.className = 'edit-btn';
        editBtn.addEventListener('click', () => onEditClick(snowmanName, height, location, creatorName, attribute));

        const nextBtn = createEl('button', 'Next');
        nextBtn.className = 'next-btn';
        nextBtn.addEventListener('click', () => onNextClick(snowmanName, height, location, creatorName, attribute));

        listEl.appendChild(editBtn);
        listEl.appendChild(nextBtn);

        return listEl;
    }

    function createYourSnowman(snowmanName, height, location, creatorName, attribute) {
        const listEl = createSectionView(snowmanName, height, location, creatorName, attribute);
        listEl.className = 'snowman-content';

        const sendBtn = createEl('button', 'Send');
        sendBtn.className = 'send-btn';
        sendBtn.addEventListener('click', onSendClick);

        listEl.children[0].appendChild(sendBtn);

        return listEl;
    }

    function onSendClick(){
        mainEl.remove();

        backBtn.className = 'back-btn';
        backBtn.addEventListener('click', onBackClick); 
        bodyEl.appendChild(backBtn);

        // imageEl.style.display = "block";
        // imageEl.style.visibility = 'visible';
        imageEl.removeAttribute("hidden");
    }

    function onBackClick(){
        location.reload();
    }

    function onNextClick(snowmanName, height, location, creatorName, attribute){
        const result = createYourSnowman(snowmanName, height, location, creatorName, attribute);
        previewEl.textContent = '';
        snowListEl.appendChild(result);
    }

    function onEditClick(snowmanName, height, location, creatorName, attribute){

        snowmanNameEl.value = snowmanName;
        heightEl.value = height;
        locationEl.value = location;
        creatorNameEl.value = creatorName;
        attributeEl.value = attribute;

        addBtn.disabled = false;
        previewEl.textContent = '';
    }


    function createEl(type, content){
        const element = document.createElement(type);

        if(content){
            element.textContent = content;
        }

        return element;
    }

}
