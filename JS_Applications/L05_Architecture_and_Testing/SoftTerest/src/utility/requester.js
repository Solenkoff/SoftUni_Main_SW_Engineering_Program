import { userHelper } from './userHelper.js';

export async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };

    //const accessToken = userHelper.getUserToken();

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = userHelper.getUserData();

    if (userData) {
        const accessToken = userHelper.getUserToken();
        options.headers['X-Authorization'] = accessToken;
    }

    try {
        const res = await fetch(url, options);
        if (!res.ok) {
            const err = await res.json();

            if (userData && err.code == 403) {
                //Access token has expired
                userHelper.clearUserData();
            }

            throw new Error(err.message);
        }
        if (res.status == 204) {
            return res;
        }
        return res.json();

    } catch (err) {
        alert(err.message);
        throw new Error(err);
    }
}

export const get = (url) => request('get', url);
export const post = (url, data) => request('post', url, data);
export const put = (url, data) => request('put', url, data);
export const patch = (url, data) => request('patch', url, data);
export const del = (url) => request('delete', url);

export const api = {
    get, post, put, patch, del
};