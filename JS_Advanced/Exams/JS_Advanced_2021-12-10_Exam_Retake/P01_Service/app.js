window.addEventListener('load', solve);

function solve() {

    const sendFormBtn = document.querySelector('#right button[type="submit"]');
    sendFormBtn.addEventListener('click', onSendForm);
    const productTypeEl = document.getElementById('type-product');
    const receivedOrdersEl = document.getElementById('received-orders');
    const completedOrdersEl = document.getElementById('completed-orders');
    const clearBtnEl = completedOrdersEl.querySelector('.clear-btn');
    clearBtnEl.addEventListener('click', onClear);

    function onSendForm(e) {
        e.preventDefault();

        const descriptionInputEl = document.getElementById('description');
        const clientNameInputEl = document.getElementById('client-name');
        const clientPhoneInputEl = document.getElementById('client-phone');

        const typeOfProduct = productTypeEl.options[productTypeEl.selectedIndex].text;
        const description = descriptionInputEl.value;
        const clientName = clientNameInputEl.value;
        const clientPhone = clientPhoneInputEl.value;

        if (!description || !clientName || !clientPhone) {
            return;
        }

        descriptionInputEl.value = '';
        clientNameInputEl.value = '';
        clientPhoneInputEl.value = '';

        const divContainer = createElement('div', undefined, 'container');
        const textForType = `Product type for repair: ${typeOfProduct}`;
        const h2Type = createElement('h2', textForType, undefined, divContainer);
        const textForClient = `Client information: ${clientName}, ${clientPhone}`;
        const h3ClientInfo = createElement('h3', textForClient, undefined, divContainer);
        const textForDescription = `Description of the problem: ${description}`;
        const h4Description = createElement('h4', textForDescription, undefined, divContainer);
        const startBtn = createElement('button', 'Start repair', 'start-btn', divContainer);
        startBtn.addEventListener('click', onStartRepair);
        const finishBtn = createElement('button', 'Finish repair', 'finish-btn', divContainer);
        finishBtn.addEventListener('click', onFinishRepair);
        finishBtn.disabled = true;

        receivedOrdersEl.appendChild(divContainer);
    }


    function onStartRepair(e) {
        e.currentTarget.disabled = true;
        const finishRepairBtn = e.currentTarget.parentNode.querySelector('.finish-btn');
        finishRepairBtn.disabled = false;
        finishRepairBtn.addEventListener('click', onFinishRepair);
    }

    function onFinishRepair(e) {
        const orderDiv = e.currentTarget.parentNode;
        Array.from(orderDiv.querySelectorAll('button')).forEach(el => el.remove());

        completedOrdersEl.appendChild(orderDiv);
    }

    function onClear(e){
        Array.from(e.currentTarget.parentNode.querySelectorAll('div')).forEach(div => div.remove());
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