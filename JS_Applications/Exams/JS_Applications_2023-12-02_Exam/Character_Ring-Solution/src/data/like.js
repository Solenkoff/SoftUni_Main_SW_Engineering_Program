import { get, post } from './request.js';


const endpoints = {
    likeCharacter: '/data/useful',
    totalLikes: (characterId) => `/data/useful?where=characterId%3D%22${characterId}%22&distinct=_ownerId&count`,
    singleUserLikes: (characterId, userId) => `/data/useful?where=characterId%3D%22${characterId}%22%20and%20_ownerId%3D%22${userId}%22&count`

};

export async function likeCharacter(characterId) {
    await post(endpoints.likeCharacter, {characterId});
}

export async function getTotalLikes(characterId) {
    return await get(endpoints.totalLikes(characterId));
}

export async function getSingleUserLikes(characterId, userId) {
    return await get(endpoints.singleUserLikes(characterId, userId));
}