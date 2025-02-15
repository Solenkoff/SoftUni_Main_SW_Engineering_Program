import { Router } from 'express';

import recipeService from '../services/recipeService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';

const recipeController = Router();


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


export default recipeController;   