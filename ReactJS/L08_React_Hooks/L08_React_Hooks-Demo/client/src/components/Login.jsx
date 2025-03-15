import { useNavigate } from "react-router";

import { Input, Button } from "antd";
import useForm from "../hooks/useForm";
import { UserOutlined, SecurityScanOutlined } from '@ant-design/icons';

export default function Login({
    onLogin,
}) {
    const navigate = useNavigate();
    const initialFormState = {
        username: '',
        password: '',
    }

    const { changeHandler, submitHandler, values } = useForm((values) => {
        onLogin(values.username);
        navigate('/send');   
    }, initialFormState)

    return (
        <form onSubmit={submitHandler}>
            <Input
                size="large"
                name="username"
                value={values.username}
                onChange={changeHandler}
                placeholder="Username"
                prefix={<UserOutlined />}
            />

            <Input
                size="large"
                name="password"
                type="password"
                value={values.password}
                onChange={changeHandler}
                placeholder="Password"
                prefix={<SecurityScanOutlined />}
            />

            <Button type="primary" htmlType="submit" >Login</Button>
        </form>
    );
}