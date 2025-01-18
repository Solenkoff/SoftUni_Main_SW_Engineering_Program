import movies from '../movies.js';

const movieService = {

    findMovie(movieId){
        //  TODO: If no such movie...
        return movies.find(movie => movie.id === movieId);
    }
}



export default movieService;