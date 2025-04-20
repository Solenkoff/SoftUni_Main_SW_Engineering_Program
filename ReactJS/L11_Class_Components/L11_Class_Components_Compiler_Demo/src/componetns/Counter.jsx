function Coutner({ count, increment }) {
    return (
        <>
            <h2>Coutner - {count}</h2>

            <button onClick={increment}>+</button>
        </>
    );
}

export default Coutner;
