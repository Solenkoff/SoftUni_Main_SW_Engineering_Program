import { del, get, post, put } from './request.js';


const endpoints = {
    catalog: '/data/characters?sortBy=_createdOn%20desc',                     //   TO BE CHANGED
    characters: '/data/characters',
    characterById: '/data/characters/'
};


export async function getAllCharacters() {
    return get(endpoints.catalog);
}

export async function getCharacterById(id) {
    return get(endpoints.characterById + id);
}

export async function createCharacter(category, imageUrl, description, moreInfo) {
    return post(endpoints.characters, {
        category,
        imageUrl,
        description,
        moreInfo
    });
}

export async function updateCharacter(id, data) {
    return put(endpoints.characterById + id, data);
}

export async function deleteCharacter(id) {
    return del(endpoints.characterById + id);
}