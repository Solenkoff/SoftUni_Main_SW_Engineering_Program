import MovieListItem from "./MovieListItem";

export default function MovieList(props) {
    return (
        <>
            <h3>MovieList:</h3>
            <div>    
                <MovieListItem movie={props.movies[0]} />
                <hr />
                <MovieListItem movie={props.movies[1]} />
                <hr />
                <MovieListItem movie={props.movies[2]} />
                <hr />
                <MovieListItem movie={props.movies[3]} />
                <hr />
                <MovieListItem movie={props.movies[4]} />
            </div>
        </>
    )
}  