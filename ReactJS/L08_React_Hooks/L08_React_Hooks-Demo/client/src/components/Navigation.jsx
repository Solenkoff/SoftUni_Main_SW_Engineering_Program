import React, { useState } from 'react';
import { Link } from 'react-router';

import { HomeOutlined, MessageOutlined, SendOutlined } from '@ant-design/icons';
import { Menu } from 'antd';

const items = [
    {
        label: <Link to="/">Home</Link>,
        key: 'home',
        icon: <HomeOutlined />,
    },
    {
        label: <Link to="/chat">Chat</Link>,
        key: 'chat',
        icon: <MessageOutlined />,
    },
    {
        label: <Link to="/send">Send</Link>,
        key: 'send',
        icon: <SendOutlined />,
    }
];

export default function Navigation() {
    const [current, setCurrent] = useState('mail');
    const onClick = (e) => {
        setCurrent(e.key);
    };

    return <Menu
        onClick={onClick}
        selectedKeys={[current]}
        mode="horizontal"
        items={items}
    />;
};