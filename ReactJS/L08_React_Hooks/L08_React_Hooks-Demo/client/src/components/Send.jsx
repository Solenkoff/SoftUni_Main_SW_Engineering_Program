import { use, useContext } from "react";

import { Input, Button, message } from "antd";
import { SendOutlined } from '@ant-design/icons';
import useForm from "../hooks/useForm";
import { UserContext } from "../contexts/UserContext";

const url = 'http://localhost:3030/jsonstore/messages';

export default function Send() {
    //const { user } = useContext(UserContext);   //  -useContext- can NOT  be used conditionally
    const { user } = use(UserContext);            //  -use- can be used conditionally

    // if(true){
    //     const {user} = use(UserContext);
    // }

    const [messageApi, contextHolder] = message.useMessage();

    const formSubmit = async (values) => {
        await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                author: user,
                content: values.message,
            }),
        });
  
        messageApi.open({
            type: 'success',
            content: 'Message sent successfully.'
        });
    }

    const { values, changeHandler, submitHandler } = useForm(formSubmit, {
        message: '',
        author: ''
    });

    return (
        <>
            {contextHolder}
            <form onSubmit={submitHandler}>
                <Input  
                    size="large"
                    name="message"
                    value={values.massage}
                    onChange={changeHandler}
                    placeholder="large size"
                    prefix={<SendOutlined />}
                />
                <Button type="primary" htmlType="submit">Send</Button>
            </form>
        </>

    );
}