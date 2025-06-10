
function handleCache(target: any, methodName: string, descriptor: PropertyDescriptor) {
    let cache: string[] = [];
    let lastCacheImestamp: Date | null = null;

    const originalMethod = descriptor.value;

    descriptor.value = function () {
            const timeNow = new Date();

        if (!lastCacheImestamp || (timeNow.getTime() - lastCacheImestamp.getTime() > 5000)) {
            const data = originalMethod.call(this);
            cache = data.slice();
            lastCacheImestamp = new Date();

            return data;
        } else {
            console.log('Returned from cache');
            return cache;
        }
    }

    return descriptor;
}

class MockWeatherDataService {
    private weatherData: string[] = [
        'Sunny 8° to 20°',
        'Partially Cloudy 7° to 19°',
        'Sunny 5° to 18°'
    ];

    addWeatherData(data: string) { this.weatherData.push(data); }

    @handleCache
    getWeatherData() { return this.weatherData; }
}



let service = new MockWeatherDataService();
console.log(service.getWeatherData())
console.log(service.getWeatherData())
service.addWeatherData('Partially Cloudy 5° to 11°');
console.log(service.getWeatherData())

//7 seconds later
setTimeout(() => console.log(service.getWeatherData()), 7000)
