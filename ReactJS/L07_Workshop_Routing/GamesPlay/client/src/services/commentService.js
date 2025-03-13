import request from "../utils/request";

const baseUrl = 'http://localhost:3030/jsonstore/comments';

export default {
    async getAll(gameId){
        const comments = await request.get(baseUrl);
        // TODO: Filter when migrate to Server / Collections  (jsonstore does not support filtering)
        // -->  Client filtering here   !!! NOT to be done otherwise

        const gameComments = Object.values(comments).filter(c => c.gameId === gameId);
        
        return gameComments;
    },
    create(email, gameId, comment) {
        return request.post(baseUrl, {email, gameId, comment});
    }
}  