import { Router } from "express";

const homeController = Router();


homeController.get('/', (req, res) => {
    res.setError('Big Error');
    res.render('home');
    // res.render('home', {pageTitle: 'TechStore | Home'});
})

export default homeController;