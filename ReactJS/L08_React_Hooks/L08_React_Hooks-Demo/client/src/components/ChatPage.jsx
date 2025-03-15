import useFetch from '../hooks/useFetch';

import { Spin } from 'antd';
import Chat from './Chat';

const url = 'http://localhost:3030/jsonstore/messages';


export default function ChatPage() {

    const [pending, messages] = useFetch(url, []);

    console.log(messages);

    if (pending) {
        return <Spin />
    }

    return (
        <>
            <Chat messages={messages} />
        </>
    );
}