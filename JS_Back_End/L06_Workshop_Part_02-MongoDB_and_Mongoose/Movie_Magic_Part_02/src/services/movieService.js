import Movie from '../models/Movie.js';

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
        const newMoviePromise = Movie.create({
            ...movieData,
            year: Number(movieData.year),
            rating: Number(movieData.rating),
        });

        return newMoviePromise; 
    }
}



export default movieService;