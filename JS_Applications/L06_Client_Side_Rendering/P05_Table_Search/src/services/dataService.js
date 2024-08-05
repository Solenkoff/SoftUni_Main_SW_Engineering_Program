import { dataApi } from "../requester.js";

const URL = 'http://localhost:3030/jsonstore/advanced/table';

async function getAll(){
    return await dataApi.get(URL);
}

async function postMatchedSearch(data){
    return await dataApi.post(URL, data);
}


export const dataService = {
    getAll, 
    postMatchedSearch
}