import Recipe from "../models/Recipe.js";


export const getAll = (filter = {}) => {
    let query = Recipe.find({});
    
    return query;
};

export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const getOne = (recipeId) => Recipe.findById(recipeId);

export const create = (recipeData, userId) => Recipe.create({ ...recipeData, owner: userId });

export const recommend = async (recipeId, userId) => {
    const recipe = await Recipe.findById(recipeId);

    if (recipe.owner.equals(userId)) {
        throw new Error('Cannot recommended your own recipe post!');
    }

    if (recipe.recommendList.includes(userId)) {
        throw new Error('You have already recommended this recipe!');
    }

    recipe.recommendList.push(userId);

    return recipe.save();
}


const recipeService = {
    getAll,
    getLatest,
    getOne,
    create,
    recommend,
   
};

export default recipeService; 