import { useState } from 'react'
import './App.css'
import MovieListItem from './components/MovieListItem';

function App() {
    const [movies, setMovies] = useState([
        'The Matrix',
        'Man of Steel',
        'The Case for Christ',
        'Lord of the Rings',
    ]);

    const removeFirstHandler = () => {
        movies.shift();  // Do NOT do this !!!
        //  ! When updating state with reference type we need to set new referane
        setMovies([...movies]);
        // setMovies(movies.slice());
    }

    //* Keys shoudld be unique among siblings !!!
    //* Keys should be unchanged between renders 
    return (
        <>
            <h2>Movie List</h2>
            <ul>
                {movies.map(movie => <MovieListItem  key={movie.id} movie={movie} />)}
            </ul>

            <button onClick={removeFirstHandler}>Remove First</button>
        </>
    )
}

export default App
