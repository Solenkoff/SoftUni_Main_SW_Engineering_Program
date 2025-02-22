import { useEffect, useState } from "react"

export default function Input() {
    const [state, setState] = useState(true);
    const [text, setText] = useState('');

    console.log('Render');

    // On Mount
    useEffect(() => {
        console.log('Mounting');
    }, []);

    // On input Change
    useEffect(() => {
        console.log(`On text change - ${text}`);

        // Clean up function before each change
        // return () => {
        //     console.log('Before new input change');
        // }
    }, [text]);

    // On button click
    useEffect(() => {
        console.log('On state change');
    }, [state]);

    // On unmount
    useEffect(() => {
        // Clean up function
        return () => {
            console.log('On unmount');
        }
    }, []);



    const buttonClickHandler = () => {
        console.log('Button clicked');

        // Toggle state
        setState((currentState) => !currentState);  // Use update function  when creating state derivative
        // setState(!state);  // ! Do NOT use this when depending on old state due to race conditions
    }

    const inputChangeHandler = (e) => {
        setText(e.target.value);

    }

    return (
        <>
            <h3>Input Component</h3>

            <input type="text" onChange={inputChangeHandler} />

            <button onClick={buttonClickHandler}>Update</button>
        </>
    )
}