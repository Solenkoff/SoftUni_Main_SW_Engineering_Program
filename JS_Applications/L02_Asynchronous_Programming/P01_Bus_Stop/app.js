function getInfo() {

    const stopIdEl = document.getElementById('stopId');
    const stopId = stopIdEl.value;
    const stopNameEl = document.getElementById('stopName');
    const busesListEl = document.getElementById('buses');

    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    busesListEl.replaceChildren();

    fetch(url)
        .then(res => responseCheck(res))
        .then(data => renderData(data))
        .catch(err => stopNameEl.textContent = 'Error');

    function responseCheck(res){
        if(res.status != 200){
            throw new Error('Invalid Stop Id!');
        }
 
        return res.json();
    }

    function renderData(busStop){
        stopNameEl.textContent = busStop.name;
        
        Object.entries(busStop.buses).forEach((key, value) =>{
            const busLiEl = document.createElement('li');
            busLiEl.textContent = `Bus ${key} arrives in ${value} minutes`;
            busesListEl.appendChild(busLiEl);
        });
        stopIdEl.value = '';
    }
}

