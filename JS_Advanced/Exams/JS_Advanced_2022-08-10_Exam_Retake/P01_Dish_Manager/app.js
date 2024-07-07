window.addEventListener("load", solve);

function solve() {

    let firstNameInputElement = document.getElementById('first-name');
    let lastNameInputElement = document.getElementById('last-name');
    let ageInputElement = document.getElementById('age');
    let dishDescriptionInputElement = document.getElementById('task');
    let genderSelectElement = document.getElementById('genderSelect');
    let formBtnElement = document.getElementById('form-btn');
    let inProgressUlElement = document.getElementById('in-progress');
    let finishedUlElement = document.getElementById('finished');
    let dishesInProgressCounterElement = document.getElementById('progress-count');

    //firstNameInputElement.value = 'Pesho';      //                            
    //lastNameInputElement.value = 'Bokov';       //    Delete !!!
    //ageInputElement.value = 44;                 // 
    //dishDescriptionInputElement.value = 'Neshto si za mandjata';   //

    formBtnElement.addEventListener('click', (e) => {
        e.preventDefault();

        let firstName = firstNameInputElement.value;
        let lastName = lastNameInputElement.value;
        let age = ageInputElement.value;
        let dishDescription = dishDescriptionInputElement.value;
        let gender = genderSelectElement.options[genderSelectElement.selectedIndex].text;
       

        if (!firstName || !lastName || !age|| !dishDescription) {
            return;
        }

        dishesInProgressCounterElement.textContent ++;
    
        firstNameInputElement.value = '';
        lastNameInputElement.value = '';
        ageInputElement.value = '';
        dishDescriptionInputElement.value = '';
    
        let inProgressLiElement = document.createElement('li');
        inProgressLiElement.classList.add('each-line');
        let articleElement = document.createElement('article');
        let fullNameH4Element = document.createElement('h4');
        fullNameH4Element.textContent = firstName + ' ' + lastName;
        let genderAgePElement = document.createElement('p');
        genderAgePElement.textContent = gender + ', ' + age;
        let descriptionPElement = document.createElement('p');
        descriptionPElement.textContent = dishDescription;

        let editButton = document.createElement('button');       
        editButton.classList.add('edit-btn');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', (e) => {

            firstNameInputElement.value = firstName;
            lastNameInputElement.value = lastName;
            ageInputElement.value = age;
            dishDescriptionInputElement.value = dishDescription;

            inProgressLiElement.remove();
            dishesInProgressCounterElement.textContent --;
        });

        let completeButton = document.createElement('button');
        completeButton.classList.add('complete-btn');
        completeButton.textContent = 'Mark as complete';
        completeButton.addEventListener('click', (e) => {
            inProgressLiElement.lastChild.remove();
            inProgressLiElement.lastChild.remove();

            dishesInProgressCounterElement.textContent --;
            finishedUlElement.appendChild(inProgressLiElement);
        });

        let clearButton = document.getElementById('clear-btn');
        clearButton.addEventListener('click', (e) => {
            finishedUlElement.textContent = '';

            // while (myNode.firstChild) {
            //     myNode.removeChild(myNode.lastChild);
            //   }
        });

        articleElement.appendChild(fullNameH4Element);
        articleElement.appendChild(genderAgePElement);
        articleElement.appendChild(descriptionPElement);

        inProgressLiElement.appendChild(articleElement);
        inProgressLiElement.appendChild(editButton);
        inProgressLiElement.appendChild(completeButton);

        inProgressUlElement.appendChild(inProgressLiElement);

    })



}
