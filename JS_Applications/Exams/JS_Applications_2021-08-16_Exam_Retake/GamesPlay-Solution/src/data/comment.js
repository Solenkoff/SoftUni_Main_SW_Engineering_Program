import { get, post } from './request.js';


const endpoints = {
    allComments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
    newComment: '/data/comments',

};


export async function getAllComments(gameId) {
    return await get(endpoints.allComments(gameId));
}

export async function addNewComment( gameId, comment ) {
    await post(endpoints.newComment, {
        gameId,
        comment
    });
}