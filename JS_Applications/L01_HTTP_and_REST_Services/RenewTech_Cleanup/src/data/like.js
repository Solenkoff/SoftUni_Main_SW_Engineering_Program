import { get, post } from './request.js';


const endpoints = {
    likeSolutionUrl: '/data/likes',
    totalLikes: (solutionId) => `/data/likes?where=solutionId%3D%22${solutionId}%22&distinct=_ownerId&count`,
    singleUserLikes: (solutionId, userId) => `/data/likes?where=solutionId%3D%22${solutionId}%22%20and%20_ownerId%3D%22${userId}%22&count`

};

export async function likeSolution(solutionId) {
    await post(endpoints.likeSolutionUrl, {solutionId});
}

export async function getTotalLikes(solutionId) {
    return await get(endpoints.totalLikes(solutionId));
}

export async function getSingleUserLikes(solutionId, userId) {
    return await get(endpoints.singleUserLikes(solutionId, userId));
}