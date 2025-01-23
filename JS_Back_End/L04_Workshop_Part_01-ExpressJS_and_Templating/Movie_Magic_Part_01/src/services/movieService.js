import { v4 as uuid } from 'uuid';
import movies from '../movies.js';

const movieService = {

    getAll( filter = {} ){
        let result = movies;

        if(filter.search){
            result = result.filter(movie => movie.title.toLowerCase().includes(filter.search.toLowerCase()));
        }

        if(filter.genre){
            result = result.filter(movie => movie.genre.toLocaleLowerCase() === filter.genre.toLocaleLowerCase());
        }

        if(filter.year){
            result = result.filter(movie => movie.year === filter.year);
        }

        return result;
    },
    findMovie(movieId){
        //  TODO: If no such movie...
        return movies.find(movie => movie.id === movieId);
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