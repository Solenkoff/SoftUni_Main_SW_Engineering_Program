window.addEventListener('load', solve);

function solve() {

    const nextBtn = document.getElementById('next-btn');
    nextBtn.addEventListener('click', onNext);
    const reservationInfoEl = document.getElementById('info-reservations');
    const infoListEl = reservationInfoEl.querySelector('.info-list');
    const confirmReservationsEl = document.getElementById('confirm-reservations');
    const confirmListEl = confirmReservationsEl.querySelector('.confirm-list');
    const h1VerificationEl = document.getElementById('verification');
    
    function onNext(e) {
        e.preventDefault();

        const firstNameInputEl = document.getElementById('first-name');
        const lastNameInputEl = document.getElementById('last-name');
        const dateInInputEl = document.getElementById('date-in');
        const dateOutInputEl = document.getElementById('date-out');
        const numberOfGuestsEl = document.getElementById('people-count');

        const firstName = firstNameInputEl.value;
        const lastName = lastNameInputEl.value;
        const dateIn = dateInInputEl.value;
        const dateOut = dateOutInputEl.value;
        const numberOfGuests = numberOfGuestsEl.value;

        if(!firstName || !lastName || !dateIn || !dateOut || !numberOfGuests){
            return;
        }

        const reservationLiEl = createElement('li', undefined, 'reservation-content');
        const articleElement = createElement('article', undefined, undefined, reservationLiEl);
        const textForName = `Name: ${firstName} ${lastName}`;
        const nameH3Element = createElement('h3', textForName, undefined, articleElement);
        const textForDateIn = `From date: ${dateIn}`;
        const dateInPElement = createElement('p', textForDateIn, undefined, articleElement);
        const textForDateOut = `To date: ${dateOut}`;
        const dateOurPElement = createElement('p', textForDateOut, undefined, articleElement);
        const textForNumGuests = `For ${numberOfGuests} people`;
        const numOfPeople = createElement('p', textForNumGuests, undefined, articleElement);

        const editButton = createElement('button', 'Edit', 'edit-btn', reservationLiEl);
        editButton.addEventListener('click', (e) => {
            e.preventDefault();
            firstNameInputEl.value = firstName;
            lastNameInputEl.value = lastName;
            dateInInputEl.value = dateIn;
            dateOutInputEl.value = dateOut;
            numberOfGuestsEl.value = numberOfGuests;

            nextBtn.disabled = false;
            e.currentTarget.parentNode.remove();
        });

        const continueButton = createElement('button', 'Continue', 'continue-btn', reservationLiEl);
        continueButton.addEventListener('click', (e) => {
            e.preventDefault();
            editButton.textContent = 'Confirm';
            editButton.className = 'confirm-btn';
            e.target.textContent = 'Cancel';
            e.target.className = 'cancel-btn';

            confirmListEl.appendChild(reservationLiEl);

            editButton.addEventListener('click', (e) => {
                e.preventDefault();
                reservationLiEl.remove();
                nextBtn.disabled = false;

                h1VerificationEl.classList.add('reservation-confirmed');
                h1VerificationEl.textContent = 'Confirmed.';
                console.log(h1VerificationEl.textContent);
            });

            e.target.addEventListener('click', (e) => {
                e.preventDefault();

                reservationLiEl.remove();
                nextBtn.disabled = false;

                h1VerificationEl.classList.add('reservation-cancelled');
                h1VerificationEl.textContent = 'Cancelled.';
                console.log(h1VerificationEl.textContent);
                
            });

        });

        infoListEl.appendChild(reservationLiEl);

        firstNameInputEl.value = '';
        lastNameInputEl.value = '';
        dateInInputEl.value = '';
        dateOutInputEl.value = '';
        numberOfGuestsEl.value = '';

        nextBtn.disabled = true;
    }


    function createElement(type, text, className, parent) {
        const newElement = document.createElement(type);
        if (text) {
            newElement.textContent = text;
        }
        if (className) {
            newElement.className = className;
        }
        if (parent) {
            parent.appendChild(newElement);
        }

        return newElement;
    }

}





