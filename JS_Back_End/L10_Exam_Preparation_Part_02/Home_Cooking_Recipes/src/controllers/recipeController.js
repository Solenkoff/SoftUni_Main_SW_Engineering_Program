import { Router } from 'express';

import recipeService from '../services/recipeService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';

const recipeController = Router();

recipeController.get('/catalog', async (req, res) => {
    const recipes = await recipeService.getAll();

    res.render('recipes/catalog', { recipes });
})

recipeController.get('/create', isAuth, (req, res) => {
    res.render('recipes/create');

});

recipeController.post('/create', isAuth, async (req, res) => {   
    const recipeData = req.body;     
    const userId = req.user.id;      

    try {
        await recipeService.create(recipeData, userId);     
        res.redirect('/recipes/catalog');                           
    } catch (err) {                                         
        res.render('recipes/create', { recipe: recipeData, error: getErrorMessage(err) });
    }
});

recipeController.get('/:recipeId/details', async (req, res) => {
    const recipeId = req.params.recipeId;
    const recipe = await recipeService.getOne(recipeId);

    const isOwner = recipe.owner.equals(req.user?.id);
    const hasRecommended = recipe.recommendList.includes(req.user?.id);
    const recommendationsCount = recipe.recommendList.length;

    res.render('recipes/details', { recipe, isOwner, hasRecommended, recommendationsCount });
});

recipeController.get('/:recipeId/recommend', isAuth, async (req, res) => {
    const recipeId = req.params.recipeId;
    const userId = req.user.id;

    try {
        await recipeService.recommend(recipeId, userId);
    } catch (err) {
        res.setError(getErrorMessage(err));
    }

    res.redirect(`/recipes/${recipeId}/details`);
});

recipeController.get('/:recipeId/delete', isAuth, async (req, res) => {
    const recipeId = req.params.recipeId;
    const userId = req.user.id;

    try {
        await recipeService.remove(recipeId, userId);

        res.redirect('/recipes/catalog');
    } catch (err) {
        res.setError(getErrorMessage(err));
        res.redirect(`/recipes/${recipeId}/details`);
    }

});




export default recipeController;   