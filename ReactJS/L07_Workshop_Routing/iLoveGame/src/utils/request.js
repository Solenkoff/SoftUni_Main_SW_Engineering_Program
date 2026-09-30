const url = "https://hcfgbaublpibdkyhllqi.supabase.co/rest/v1";
const apiKey = "sb_publishable_pA-XOlx980ShnF8IvH0rag_D7upZu9Q";

export default async function request(path = '/', method = "GET", data = null, specs = {}) {
    const options = {
        headers:{
            apiKey,
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

    const response = await fetch(`${url}${path}`, options);

    if(!response.ok){
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    if(response.status === 204){
        return null;
    }

    return response.json();
}