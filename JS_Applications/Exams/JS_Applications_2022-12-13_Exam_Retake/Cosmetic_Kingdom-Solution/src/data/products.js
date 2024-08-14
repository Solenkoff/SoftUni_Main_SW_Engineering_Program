import { del, get, post, put } from './request.js';


const endpoints = {
    catalog: '/data/products?sortBy=_createdOn%20desc',          //   TO BE CHANGED
    products: '/data/products',
    productById: '/data/products/'
};


export async function getAllProducts() {
    return get(endpoints.catalog);
}

export async function getProductById(id) {
    return get(endpoints.productById + id);
}

export async function createProduct(name, imageUrl, category, description, price) {
    return post(endpoints.products, {
        name,
        imageUrl,
        category,
        description,
        price
    });
}

export async function updateProduct(id, data) {
    return put(endpoints.productById + id, data);
}

export async function deleteProduct(id) {
    return del(endpoints.productById + id);
}