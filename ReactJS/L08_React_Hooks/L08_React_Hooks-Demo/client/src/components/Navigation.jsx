import React, { useState } from 'react';
import { Link } from 'react-router';

import { HomeOutlined, MessageOutlined } from '@ant-design/icons';
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
    }
];

export default function Navigation() {
    const [current, setCurrent] = useState('mail');
    const onClick = (e) => {
        console.log('click ', e);
        setCurrent(e.key);
    };

    return <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items} />;
};