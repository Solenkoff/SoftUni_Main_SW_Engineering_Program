import { del, get, post, put } from './request.js';


const endpoints = {
    market: '/data/cyberpunk?sortBy=_createdOn%20desc',       //   TO BE CHANGED
    items: '/data/cyberpunk',       //   TO BE CHANGED
    itemById: '/data/cyberpunk/',     //
};

export async function getAllItems(){
    return get(endpoints.market);
}

export async function getItemById(id){
    return get(endpoints.itemById + id);
}

export async function createItem( item, imageUrl, price, availability, type, description){
    return post(endpoints.items, {
        item, 
        imageUrl, 
        price, 
        availability,
        type,
        description
    });
}

export async function updateItem(id, data){
    return put(endpoints.itemById + id, data);
}

export async function deleteItem(id){
    return del(endpoints.itemById + id);
}