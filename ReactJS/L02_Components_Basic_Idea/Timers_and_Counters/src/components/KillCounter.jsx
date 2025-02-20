import { useState } from "react";

export default function KillCounter() {
    const [count, setCount] = useState(0);

    const increaseCountClickHandler = (e) => {
        setCount(count + 1);
    }

    const decrementCountClickHandler = () => {
        setCount(count - 1);
    }

    const isMax = count >= 10;

    if (count > 10) {
        return (
            <>
                <h1>Game Over</h1>
                <hr />
            </>
        )
    }

    let titleElement = <h2>Kill Counter</h2>;
    if (count == 1) {
        titleElement = <h6>First Blood!</h6>;
    }

    switch (count) {
        case 2: titleElement = <h6>Double Kill</h6>; break;
        case 3: titleElement = <h5>Triple Kill</h5>; break;
        case 4: titleElement = <h4>Multi Kill</h4>; break;
        case 5: titleElement = <h3>Monster Kill</h3>; break;
        case 6: titleElement = <h2>Unstoppable</h2>; break;
        case 7: titleElement = <h1>God Like</h1>; break;
    }


    return (
        <>
            {titleElement}
            <div>{count}</div>
            <button onClick={increaseCountClickHandler}>+</button>
            {count > 7
                ? <button onClick={decrementCountClickHandler}>-</button>
                : <p>No decrement yet!</p>
            }

            {isMax && <p>Watch Out!</p>}
            <hr />
        </>
    )
} 