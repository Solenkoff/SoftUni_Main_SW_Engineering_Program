function attachEvents() {

    const locationEl = document.getElementById('location');
    const submitBtn = document.getElementById('submit');
    const forecastDivEl = document.getElementById('forecast');
    const currWeatherEl = document.getElementById('current');
    const upcomingWeatherEl = document.getElementById('upcoming');

    submitBtn.addEventListener('click', getWeather);

    const baseUrl = 'http://localhost:3030/jsonstore/forecaster';

    const symbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degree': '&#176',
    };


    async function getWeather() {
        let location = locationEl.value;
        
        const locationCode = await getLocationCode(location);

        const currentEl = document.querySelector('#current .forecasts');
        const upcomingEl = document.querySelector('#upcoming .forecast-info');
        if(currentEl || upcomingEl){
            currentEl.remove();
            upcomingEl.remove();
        }

       getCurrent(locationCode);
       getUpcoming(locationCode);

       forecastDivEl.style.display = 'block';

    }

    async function getLocationCode(location) {
        try {
            const url = 'http://localhost:3030/jsonstore/forecaster/locations';
            const response = await fetch(url);
            const data = await response.json();

            return data.find((currentDiv) => currentDiv.name.toLowerCase() == location.toLowerCase()).code;
        } catch (error) {
            errorHandler(error);
        }
    }

    
    async function getCurrent(locationCode) {
        try {
            const url = `${baseUrl}/today/${locationCode}`;
            const response = await fetch(url);
            const data = await response.json();

            renderTodaysWeather(data);
        } catch (error) {
            errorHandler(error);
        }
    }

    async function getUpcoming(locationCode) {
        try {
            const url = `${baseUrl}/upcoming/${locationCode}`;
            const response = await fetch(url);
            const data = await response.json();

            renderUpcomingWeather(data);
        } catch (error) {
            errorHandler(error);
        }
    }

    function renderTodaysWeather(data) {
        const divContainer = createEl('div', undefined, 'forecasts');

        const conditionSymbol = symbols[data.forecast.condition];
        const symbolSpanEl = createEl('span', conditionSymbol, 'condition symbol');

        const conditionContainer = createEl('span', undefined, 'condition');
        const citySpanEl = createEl('span', data.name, 'forecast-data');
        const lowTemp = data.forecast.low + symbols.Degree;
        const highTemp = data.forecast.high + symbols.Degree;
        const temperatureSpanEl = createEl('span', `${lowTemp}/${highTemp}`, 'forecast-data');
        const conditionSpanEl = createEl('span', data.forecast.condition, 'forecast-data');

        conditionContainer.appendChild(citySpanEl);
        conditionContainer.appendChild(temperatureSpanEl);
        conditionContainer.appendChild(conditionSpanEl);
        divContainer.appendChild(symbolSpanEl);
        divContainer.appendChild(conditionContainer);

        currWeatherEl.appendChild(divContainer);
    }

    function renderUpcomingWeather(data){
        const divContainer = createEl('div', undefined, 'forecast-info');

        for (const day of data.forecast) {
            const dayContainerEl = createEl('span', undefined, 'upcoming');
            const conditionSymbol = symbols[day.condition];
            const symbolSpanEl = createEl('span', conditionSymbol, 'symbol');
            const lowTemp = day.low + symbols.Degree;
            const highTemp = day.high + symbols.Degree;
            const temperatureSpanEl = createEl('span', `${lowTemp}/${highTemp}`, 'forecast-data');
            const conditionSpanEl = createEl('span', day.condition, 'forecast-data');

            dayContainerEl.appendChild(symbolSpanEl);
            dayContainerEl.appendChild(temperatureSpanEl);
            dayContainerEl.appendChild(conditionSpanEl);

            divContainer.appendChild(dayContainerEl);
        }

        upcomingWeatherEl.appendChild(divContainer);
    }


    function errorHandler(error) {
        forecastDivEl.style.display = 'block';
        forecastDivEl.textContent = 'Error';
    }

    function createEl(type, content, classNames) {
        const element = document.createElement(type);

        if (content) {
            if (type == 'span') {
                element.innerHTML = content;
            } else {
                element.textContent = content;
            }
        }
        if (classNames) {
            element.className = classNames;
        }

        return element;
    }
}

attachEvents();