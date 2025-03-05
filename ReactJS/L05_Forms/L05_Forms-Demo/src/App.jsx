import ControlledForm from './components/ControlledForm'
import UncontrolledForm from './components/UncontrolledForm'
import UncontrolledFormRef from './components/UncontrolledFormRef'
import UnifiedControlledForm from './components/UnifiedControlledForm'
import UseRef from './components/UseRef'

function App() {

    return (
        <>
            <UncontrolledForm />

            <ControlledForm />

            <UnifiedControlledForm />

            <UseRef />

            <UncontrolledFormRef />
        </>
    )
}

export default App
