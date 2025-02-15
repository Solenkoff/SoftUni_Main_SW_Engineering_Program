import Recipe from "../models/Recipe.js";


export const getAll = (filter = {}) => {
    let query = Recipe.find({});
    
    return query;
};

export const create = (recipeData, userId) => Recipe.create({ ...recipeData, owner: userId });


const recipeService = {
    getAll,
    create,
   
};

export default recipeService; 