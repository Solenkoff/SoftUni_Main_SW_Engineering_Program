import { userHelper } from './userHelper.js';

async function requester(method, url, data){
    const options = {
        method,
        headers: {}
    };

    const accessToken = userHelper.getUserToken();
    if(accessToken){
        options.headers['X-Authorization'] = accessToken;
    }

    if(data){
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        const response = await fetch(url, options);
        if(!response.ok){
            // if(response.status === 403){

            // }
            const error = await response.json();
            throw new Error(error.message);
        }

        if(response.status === 204){
            return response;
        }

        return await response.json();

    } catch (error) {
        alert(error);
        throw new Error(error.message);
    }
}

async function get(url){
    return await requester('GET', url);
}

async function post(url, data){
    return await requester('POST', url, data);
}

async function put(url, data){
    return await requester('PUT', url, data);
}

async function del(url){
    return await requester('DELETE', url);
}


export const api = {
    get,
    put,
    post,
    del
}

