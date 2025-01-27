async function requester(method, url, data){
    const option = {
        method
    }
    if(data){
        option['headers'] = {
            'Content-Type': 'application/json'
        };
        option.body =  JSON.stringify(data);
    }

    try {
        const response = await fetch(url, option);
        const data = await response.json();
        return data;
    } catch (error) {
        alert(error);
    }

}

async function get(url){
    return requester('GET', url);
}

async function post(url, data){
    return requester('POST', url, data);
}


export const dataApi = {
    get,
    post
}