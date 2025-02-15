import Recipe from "../models/Recipe.js";


export const getAll = (filter = {}) => {
    let query = Recipe.find({});
    
    return query;
};

export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const getOne = (recipeId) => Recipe.findById(recipeId);

export const create = (recipeData, userId) => Recipe.create({ ...recipeData, owner: userId });


const recipeService = {
    getAll,
    getLatest,
    getOne,
    create,
   
};

export default recipeService; 