import { v4 as uuid } from 'uuid';
import movies from '../movies.js';

const movieService = {

    getAll(){
        return movies;
    },
    findMovie(movieId){
        //  TODO: If no such movie...
        return movies.find(movie => movie.id === movieId);
    },
    createMovie(movieData){
        const newMovie = { 
            id: uuid(),
            ...movieData,
            rating: Number(movieData.rating)
        }
 
        movies.push(newMovie); 
    }
}



export default movieService;