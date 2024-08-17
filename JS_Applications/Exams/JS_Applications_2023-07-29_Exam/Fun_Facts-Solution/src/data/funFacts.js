import { del, get, post, put } from './request.js';


const endpoints = {
    catalog: '/data/facts?sortBy=_createdOn%20desc',                     //   TO BE CHANGED
    funFacts: '/data/facts',
    funFactById: '/data/facts/'
};


export async function getAllFunFacts() {
    return get(endpoints.catalog);
}

export async function getFunFactById(id) {
    return get(endpoints.funFactById + id);
}

export async function createFunFact(category, imageUrl, description, moreInfo) {
    return post(endpoints.funFacts, {
        category,
        imageUrl,
        description,
        moreInfo
    });
}

export async function updateFunFact(id, data) {
    return put(endpoints.funFactById + id, data);
}

export async function deleteFunFact(id) {
    return del(endpoints.funFactById + id);
}