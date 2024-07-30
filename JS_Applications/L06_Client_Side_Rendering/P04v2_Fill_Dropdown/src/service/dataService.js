import { dataApi } from '../requester.js';

const URL = "http://localhost:3030/jsonstore/advanced/dropdown";


async function getAllOption(){
    return await dataApi.get(URL);
}

async function postNewOption(data){
    return await dataApi.post(URL, data);
}

export const dataService = {
    getAllOption,
    postNewOption
}