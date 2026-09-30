const mainUrl = import.meta.env.VITE_MAIN_URL;

export default async function request(path = '/', method = "GET", data = null, specs = {}) {
    const options = {
        headers:{
            apiKey: import.meta.env.VITE_API_KEY,
        },
        ...specs   
    };

    if(method !== "GET")
    {
        options.method = method;
    }

    if(data){
        options.headers["Content-Type"] = "application/json";
        options.body = JSON.stringify(data);
    }

    const response = await fetch(`${mainUrl}${path}`, options);

    if(!response.ok){
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    if(response.status === 204){
        return null;
    }

    return response.json();
}