import { del, get, post, put } from './request.js';


const endpoints = {
    catalog: '/data/motorcycles?sortBy=_createdOn%20desc',                        //   TO BE CHANGED
    searchCatalog: (model) => `/data/motorcycles?where=model%20LIKE%20%22${model}%22`,      
    motorcycles : '/data/motorcycles',       
    motorcycleById: '/data/motorcycles/',     
};

export async function getAllMotorcycles (){
    return get(endpoints.catalog);
}

export async function getAllMotorcyclesByModel(model){
    return get(endpoints.searchCatalog(model));
}

export async function getMotorcycleById(id){
    return get(endpoints.motorcycleById + id);
}

export async function createMotorcycle( model, imageUrl, year, mileage, contact, about){
    return post(endpoints.motorcycles, {
        model, 
        imageUrl, 
        year, 
        mileage, 
        contact,
        about
    });
}

export async function updateMotorcycle(id, data){
    return put(endpoints.motorcycleById + id, data);
}

export async function deleteMotorcycle(id){
    return del(endpoints.motorcycleById + id);
}