import Recipe from "../models/Recipe.js";


export const getAll = (filter = {}) => {
    let query = Recipe.find({});

    if (filter.title) {
        query = query.find({ title: { $regex: filter.title, $options: 'i' }});
        
    }
    
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

export const remove = async (recipeId, userId) => {
    const recipe = await Recipe.findById(recipeId);
    if (!recipe.owner.equals(userId)) {
        throw new Error('Only owner can delete their post!');
    }

    return Recipe.findByIdAndDelete(recipeId);
}

export const updateOne = async (recipeId, userId, recipeData) => {
    const recipe = await getOne(recipeId);

    if (!recipe.owner.equals(userId)) {
        throw new Error('Only owner can  edit their post!');
    }

    return Recipe.findByIdAndUpdate(recipeId, recipeData, { runValidators: true }); 
}


const recipeService = {
    getAll,
    getLatest,
    getOne,
    create,
    recommend,
    remove,
    updateOne,
};


export default recipeService; 