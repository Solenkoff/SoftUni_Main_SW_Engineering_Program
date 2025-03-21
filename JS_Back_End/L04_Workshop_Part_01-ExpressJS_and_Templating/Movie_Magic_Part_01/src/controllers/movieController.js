import { Router } from 'express';

import movieService from '../services/movieService.js';

const movieController = Router();

movieController.get('/search', ( req, res ) => {
    const filter = req.query;
    const movies = movieService.getAll(filter);

    res.render('search', { movies, filter });
})

movieController.get('/create', (req, res) => {
    res.render('create');
})

movieController.post('/create', (req, res) => { 
    const newMovieData = req.body;
    
    movieService.createMovie(newMovieData);
    
    res.redirect('/');
})

movieController.get('/:movieId/details', (req, res) => {
    const movieId = req.params.movieId;
    const movie = movieService.findMovie(movieId);

    res.render('details', { movie });
})


export default movieController; 