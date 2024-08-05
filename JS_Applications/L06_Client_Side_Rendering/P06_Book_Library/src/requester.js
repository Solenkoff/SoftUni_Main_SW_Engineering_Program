async function requester(method, url, data) {
    const option = {
        method
    }
    if (data) {
        option['headers'] = {
            'Content-Type': 'application/json'
        }
        option.body = JSON.stringify(data);
    }

    try {
        const response = await fetch(url, option);
        const responseData = response.json();
        return responseData;
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

async function update(url, data){
    return requester('PUT', url, data);
}

async function del(url){
    return requester('DELETE', url)
}


export const dataApi = {
    get,
    post,
    update,
    del
}