import { useState } from "react";
import TodoItem from "./TodoItem";

const initialTodos = [
    { id: 1, text: 'Do homework', isCompleted: false },
    { id: 2, text: 'Cook meal', isCompleted: false },
    { id: 3, text: 'Fitness', isCompleted: false },
];

function TodoList() {
    const [todos, setTodos] = useState(initialTodos);

    const toggleTodoHandler = (todoId) => {
        setTodos(state => state.map(todo => todoId === todo.id ? { ...todo, isCompleted: !todo.isCompleted } : todo))
    };

    // const calculateMeaningOfLife = () => {
    //     // Heavy Calculation
    //     function pauseComp(ms) {
    //         var curr = new Date().getTime();
    //         ms += curr;
    //         while (curr < ms) {
    //             curr = new Date().getTime();
    //         }
    //     }

    //     pauseComp(1000);

    //     return 42;
    // };

    // const meaningOfLife = calculateMeaningOfLife();
    const meaningOfLife = 42;

    return (
        <>
            <h2>Todos</h2>

            <ul>
                {todos.map(todo => <TodoItem
                    key={todo.id}
                    {...todo}
                    onToggle={toggleTodoHandler}
                />)}
            </ul>

            <p>Meaning of life: {meaningOfLife}</p>
        </>
    );
}

export default TodoList;
