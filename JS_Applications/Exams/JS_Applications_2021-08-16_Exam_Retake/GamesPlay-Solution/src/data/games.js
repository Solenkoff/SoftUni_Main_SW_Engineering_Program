import { del, get, post, put } from './request.js';


const endpoints = {
    latestGames: '/data/games?sortBy=_createdOn%20desc&distinct=category',   
    catalog: '/data/games?sortBy=_createdOn%20desc',          //   TO BE CHANGED
    games: '/data/games',
    gameById: '/data/games/'
};

export async function getLatestGames() {
    return get(endpoints.latestGames);
}

export async function getAllGames() {
    return get(endpoints.catalog);
}

export async function createGame(title, category, maxLevel, imageUrl, summary) {
    return post(endpoints.games, {
        title, 
        category, 
        maxLevel, 
        imageUrl, 
        summary
    });
}

export async function getGameById(id) {
    return get(endpoints.gameById + id);
}


export async function updateGame(id, data) {
    return put(endpoints.gameById + id, data);
}

export async function deleteGame(id) {
    return del(endpoints.gameById + id);
}