function solve() {

    const infoBoxEl = document.querySelector('#info span');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule';

    let currStopName = 'depot';
    let nextStopId = 'depot';

    function depart() {
        fetch(`${baseUrl}/${nextStopId}`)
            .then(res => resCheck(res))
            .then(data => renderDepart(data))
            .catch(err => showError(err));
    }

    function arrive() {
        infoBoxEl.textContent = `Arriving at ${currStopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };

  
    function renderDepart(data){
        currStopName = data.name;
        nextStopId = data.next;
        infoBoxEl.textContent = `Next stop ${currStopName}`;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function resCheck(res){
        if(res.status != 200){
            throw new Error('Info not found!');
        }
        
        return res.json();
    }

    function showError(err){
        infoBoxEl.textContent = 'Error';
        departBtn.disabled = true;
        arriveBtn.disabled = true;
    }
}

let result = solve();