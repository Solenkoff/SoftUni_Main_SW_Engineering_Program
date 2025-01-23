import { Router } from 'express';

import movieService from '../services/movieService.js';

const router = Router();

router.get('/', async (req, res) => {
    const movies = await movieService.getAll();

    // #1 Convert documents to plain object
    // const plainMovies = movies.map(m => m.toObject());  
    // #2 with <lean> in movieService -> returns [{},{},..]
    // #3  with <lean> here (you decide where to lean -> turn it into [{},{},..])
    // * #4  as it is with  runtimeOptions: { allowProtoPropertiesByDefault: true } in index.js when setting up engine

    res.render('home', { movies });
});

router.get('/about', (req, res) => { 
    res.render('about');
});


export default router;