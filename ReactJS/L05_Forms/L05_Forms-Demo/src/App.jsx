import ControlledForm from './components/ControlledForm'
import UncontrolledForm from './components/UncontrolledForm'
import UnifiedControlledForm from './components/UnifiedControlledForm'

function App() {

    return (
        <>
            <UncontrolledForm />

            <ControlledForm />

            <UnifiedControlledForm />

            <UseRef />
        </>
    )
}

export default App
