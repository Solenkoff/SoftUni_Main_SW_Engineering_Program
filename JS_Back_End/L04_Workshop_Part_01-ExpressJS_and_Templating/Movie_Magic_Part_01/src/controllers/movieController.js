import { Router } from 'express';

const movieController = Router();


movieController.get('/create', ( req, res ) => {
    res.render('create');
})

movieController.get('/details', ( req, res ) => {
    res.render('details', { movie});
})


export default movieController;