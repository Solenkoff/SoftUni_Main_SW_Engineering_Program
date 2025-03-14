import useFetch from "./hooks/useFetch"
import { Spin } from 'antd';


import Chat from "./components/Chat"

const url = 'http://localhost:3030/jsonstore/messages';

function App() {
    const [pending, messages] = useFetch(url, []);

    console.log(messages);
    
    return (
        <>
            {pending
                ? <Spin />
                : <Chat messages={messages} />
            }
        </>
    ) 
}

export default App
