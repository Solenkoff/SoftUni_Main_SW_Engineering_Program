import './App.css'
import Coutner from './componetns/Counter'
import TodoList from './componetns/TodoList'
import { useState } from "react";

function App() {
    const [count, setCount] = useState(0);

    const incrementCounterHandler = () => {
        setCount(c => c + 1);
    }

    return (
        <>
            <h1>ToDo List</h1>

            <TodoList />

            <Coutner count={count} increment={incrementCounterHandler} />
        </>
    )
}

export default App
