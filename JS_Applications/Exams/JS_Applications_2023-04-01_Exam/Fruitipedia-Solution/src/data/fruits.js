import { del, get, post, put } from './request.js';


const endpoints = {
    catalog: '/data/fruits?sortBy=_createdOn%20desc',                        //   TO BE CHANGED
    searchCatalog: (name) => `/data/fruits?where=name%20LIKE%20%22${name}%22`,      
    fruits : '/data/fruits',       
    fruitById: '/data/fruits/',     
};

export async function getAllFruits (){
    return get(endpoints.catalog);
}

export async function getAllFruitsByName(name){
    return get(endpoints.searchCatalog(name));
}

export async function getFruitById(id){
    return get(endpoints.fruitById + id);
}

export async function createFruit( name, imageUrl, description, nutrition ){
    return post(endpoints.fruits, {
        name, 
        imageUrl, 
        description, 
        nutrition
    });
}

export async function updateFruit(id, data){
    return put(endpoints.fruitById + id, data);
}

export async function deleteFruit(id){
    return del(endpoints.fruitById + id);
}