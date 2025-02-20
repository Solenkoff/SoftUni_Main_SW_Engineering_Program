import './App.css'
import BrokenTimer from './components/BrokenTimer'
import Counter from './components/Counter'
import KillCounter from './components/KillCounter'
import Timer from './components/timer'

function App() {
   

    return (
        <>
            <h1>Timers and Counters</h1>

            <BrokenTimer />

            <Timer />

            <Counter />

            <KillCounter />
        </>
    )
}
 
export default App
