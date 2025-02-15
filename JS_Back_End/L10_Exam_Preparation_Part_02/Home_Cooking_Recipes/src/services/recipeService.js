import Recipe from "../models/Recipe.js";


export const create = (recipeData, userId) => Recipe.create({ ...recipeData, owner: userId });


const recipeService = {
    create,
   
};

export default recipeService; 