import { Router } from "express";

import recipeService from "../services/recipeService.js";


const homeController = Router();


homeController.get('/', async (req, res) => {
    const latestResipes = await recipeService.getLatest();
    res.render('home', { recipes: latestResipes });
});


export default homeController; 