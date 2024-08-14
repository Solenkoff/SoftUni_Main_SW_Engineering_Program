import { get, post } from './request.js';


const endpoints = {
    buyProductUrl: '/data/bought',
    totalBuys: (productId) => `/data/bought?where=productId%3D%22${productId}%22&distinct=_ownerId&count`,
    singleUserBuys: (productId, userId) => `/data/bought?where=productId%3D%22${productId}%22%20and%20_ownerId%3D%22${userId}%22&count`

};

export async function buyProduct(productId) {
    await post(endpoints.buyProductUrl, {productId});
}

export async function getTotalBuys(productId) {
    return await get(endpoints.totalBuys(productId));
}

export async function getSingleUserBuys(productId, userId) {
    return await get(endpoints.singleUserBuys(productId, userId));
}