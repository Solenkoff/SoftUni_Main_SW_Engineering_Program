import Recipe from "../models/Recipe.js";


export const getAll = (filter = {}) => {
    let query = Recipe.find({});
    
    return query;
};

export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const create = (recipeData, userId) => Recipe.create({ ...recipeData, owner: userId });


const recipeService = {
    getAll,
    getLatest,
    create,
   
};

export default recipeService; 