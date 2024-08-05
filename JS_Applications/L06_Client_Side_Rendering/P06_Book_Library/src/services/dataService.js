import { dataApi } from '../requester.js';

const URL = 'http://localhost:3030/jsonstore/collections/books';

async function getAllBooks(){
    return await dataApi.get(URL);
}

async function getSingleBook(id){
    return await dataApi.get(URL + '/' + id);
}

async function postSingleBook(data){
    return await dataApi.post(URL, data);
}

async function updateBook(id, data){
    return await dataApi.update(URL + '/' + id, data)
}

async function deleteBook(id){
    return await dataApi.del(URL + '/' + id)
}


export const dataService = {
    getAllBooks,
    getSingleBook,
    postSingleBook,
    updateBook,
    deleteBook
}