export default function BrokenTimer() {
    let timer = 1;

    //* Does Not Work !!!
    // setInterval(() => {
    //     timer++;
    // }, 1000);

    return (
        <>
            <h2>BrokenTimer | Not Working</h2>
            <div>{timer}</div>
            <hr />
        </>
    )
}