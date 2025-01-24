import { v4 as uuid } from 'uuid';
import Movie from '../models/Movie.js';
import movies from '../movies.js';

const movieService = {

    getAll( filter = {} ){
        //  #2 from homeController -> <lean>
        // let result = await  Movie.find({}).lean();  // with async

        let query =  Movie.find({}); 

        if(filter.search){
            // TODO  fix partial search to be case sensitive
            query = query.where({title: filter.search});
        }

        if(filter.genre){
            // TODO  fix partial search to be case sensitive
            query = query.where({genre: filter.genre});
        }

        if(filter.year){
            // TODO  fix partial search to be case sensitive
            query = query.where({year: Number(filter.year)});
        }

        return query;
    },
    getOne(movieId){
        //  TODO: If no such movie...
        const result = Movie.findById(movieId);

        return result;
    },
    createMovie(movieData){
        const newId = uuid();

        movies.push({
            id: newId,
            ...movieData,
            rating: Number(movieData.rating),
        });

        return newId;
    }
}



export default movieService;