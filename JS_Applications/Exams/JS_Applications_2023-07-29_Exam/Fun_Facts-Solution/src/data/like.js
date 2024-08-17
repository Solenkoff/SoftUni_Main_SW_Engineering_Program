import { get, post } from './request.js';


const endpoints = {
    likeFunFactUrl: '/data/likes',
    totalLikes: (funFactId) => `/data/likes?where=factId%3D%22${funFactId}%22&distinct=_ownerId&count`,
    singleUserLikes: (funFactId, userId) => `/data/likes?where=factId%3D%22${funFactId}%22%20and%20_ownerId%3D%22${userId}%22&count`

};

export async function likeFunFact(funFactId) {
    await post(endpoints.likeFunFactUrl, {funFactId});
}

export async function getTotalLikes(funFactId) {
    return await get(endpoints.totalLikes(funFactId));
}

export async function getSingleUserLikes(funFactId, userId) {
    return await get(endpoints.singleUserLikes(funFactId, userId));
}