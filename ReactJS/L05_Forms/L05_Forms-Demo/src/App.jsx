import ControlledForm from './components/ControlledForm'
import FormAction from './components/FormAction'
import UncontrolledForm from './components/UncontrolledForm'
import UncontrolledFormRef from './components/UncontrolledFormRef'
import UnifiedControlledForm from './components/UnifiedControlledForm'
import UseActionState from './components/UseActionState'
import UseTransition from './components/UseTransition'
import UseRef from './components/UseRef'

function App() {

    return (
        <>
            <UncontrolledForm />

            <ControlledForm />

            <UnifiedControlledForm />

            <UseRef />

            <UncontrolledFormRef />

            <FormAction />

            <UseTransition />

            <UseActionState />
        </>
    )
}

export default App
