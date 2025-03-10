import { Router } from 'express';

import movieService from '../services/movieService.js';
import castService from '../services/castService.js';

const movieController = Router();

movieController.get('/search', async (req, res) => {
    const filter = req.query;
    const movies = await movieService.getAll(filter);

    res.render('search', { movies, filter });
})

movieController.get('/create', (req, res) => {
    res.render('create');
})

movieController.post('/create', async (req, res) => {
    const newMovieData = req.body;

    await movieService.createMovie(newMovieData);

    res.redirect('/');
})

movieController.get('/:movieId/details', async (req, res) => {
    const movieId = req.params.movieId;
    const movie = await movieService.getOneWithCasts(movieId);
    // const casts = await castService.getAll(movie.casts);  -> Getting all casts that are present in the movie(movie.casts -> ids)

    res.render('movie/details', { movie });
})

movieController.get('/:movieId/attach-cast', async (req, res) => {
    const movieId = req.params.movieId;
    const movie = await movieService.getOne(movieId);
    const casts = await castService.getAll({exclude: movie.casts.map(c => c.cast)});

    res.render('movie/attach-cast', { movie, casts });
})

movieController.post('/:movieId/attach-cast', async (req, res) => {
 
    const castId = req.body.cast;
    const movieId = req.params.movieId;
    const character = req.body.character;
    await movieService.attachCast(movieId, castId, character);

    res.redirect(`/movies/${movieId}/details`);
});


export default movieController;  