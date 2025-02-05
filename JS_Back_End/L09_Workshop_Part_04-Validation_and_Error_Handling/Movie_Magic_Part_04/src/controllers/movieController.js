import { Router } from 'express';

import movieService from '../services/movieService.js';
import castService from '../services/castService.js';
import { isAuth } from '../../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtils.js';

const movieController = Router();

//   !!!  Use only when all the controller needs this auth, otherwise place it after those that do not need auth(separate them), or in each method/function
//   !   movieController.use(isAuth);    

movieController.get('/search', async (req, res) => {
    const filter = req.query;
    const movies = await movieService.getAll(filter);

    res.render('search', { movies, filter });
});

movieController.get('/create', isAuth, (req, res) => {    
    res.render('create');
});

movieController.post('/create', isAuth, async (req, res) => {
    const newMovieData = req.body;
    const userId = req.user?.id;

    await movieService.createMovie(newMovieData, userId);

    res.redirect('/');
});

movieController.get('/:movieId/details', async (req, res) => {
    const movieId = req.params.movieId;
    const movie = await movieService.getOneWithCasts(movieId);
    // const casts = await castService.getAll(movie.casts);  -> Getting all casts that are present in the movie(movie.casts -> ids)
    const isCreator = movie.creator?.equals(req.user?.id);
    //const isCreator = movie.creator &&  movie.creator.toString() === req.user?.id;  // movie.creator is  ObjectId
    res.render('movie/details', { movie, isCreator, user: req.user });
});

movieController.get('/:movieId/attach-cast', isAuth, async (req, res) => {
    const movieId = req.params.movieId;
    const movie = await movieService.getOne(movieId);
    const casts = await castService.getAll({ exclude: movie.casts.map(c => c.cast) });

    res.render('movie/attach-cast', { movie, casts });
});

movieController.post('/:movieId/attach-cast', isAuth, async (req, res) => {

    const castId = req.body.cast;
    const movieId = req.params.movieId;
    const character = req.body.character;
    await movieService.attachCast(movieId, castId, character);

    res.redirect(`/movies/${movieId}/details`);
});

movieController.get('/:movieId/delete', isAuth, async (req, res) => {
    const movieId = req.params.movieId;

    const movie = await movieService.getOne(movieId);

    if (!movie.creator?.equals(req.user?.id)) {
        
        res.setError('You are not the movie owner!');
        
        return res.redirect('404');
    }

    await movieService.delete(movieId);

    res.redirect('/');
});


movieController.get('/:movieId/edit', isAuth, async (req, res) => {
    const movieId = req.params.movieId;
    const movie = await movieService.getOne(movieId);

    // if (!movie.creator?.equals(req.user?.id)) {
    //     return res.redirect('404');
    // }

    const categories = getCategoriesViewData(movie.category);

    res.render('movie/edit', { movie, categories });
});
    
movieController.post('/:movieId/edit', isAuth, async (req, res) => {
    const movieData = req.body;
    const movieId = req.params.movieId;    

    //  TODO: Check if creator
    try {
        await movieService.update(movieId, movieData);
    } catch (err) {
        const categories = getCategoriesViewData(movieData.category);
        return res.render('movie/edit', { movie: movieData, categories,  error: getErrorMessage(err) });
    }
    
    res.redirect(`/movies/${movieId}/details`); 
}); 
 

function getCategoriesViewData(category){
    const categoriesMap = {
        'tv-show': 'TV Show',
        'animation': 'Animation',
        'movie': 'Movie',
        'documentary': 'Documentary',
        'short-film': 'Short Film',
    }

    const categories = Object.keys(categoriesMap).map(value => ({
        value,
        label: categoriesMap[value],
        selected: value === category ? 'selected' : '',
    }));

    return categories;
}

export default movieController;   