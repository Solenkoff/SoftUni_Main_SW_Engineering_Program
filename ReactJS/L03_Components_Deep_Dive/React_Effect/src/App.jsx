import { useState } from 'react'
import './App.css'
import Input from './components/input'
import Timer from './components/Timer';

function App() {
    const [show, setShow] = useState(false);


    const showButtonHandler = () => {
        setShow(state => !state);
    }

    return (
        <>
            <h1>UseEffect Hook</h1>

            <button onClick={showButtonHandler}>{show ? 'Hide' : 'Show'} Input</button>

            {show && <Input />}

            <hr />

            <Timer />
        </>
    )
}

export default App
