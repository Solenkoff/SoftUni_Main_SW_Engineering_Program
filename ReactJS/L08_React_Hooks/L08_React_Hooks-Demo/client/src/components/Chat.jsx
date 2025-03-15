import React from 'react';
import { Avatar, List } from 'antd';

export default function Chat({
    messages,
}) {
    return (
        <List
            className="demo-loadmore-list"
            itemLayout="horizontal"
            dataSource={messages}
            bordered={true}
            renderItem={(message) => (
                <List.Item
                    actions={[<a key="list-loadmore-edit">edit</a>, <a key="list-loadmore-more">more</a>]}
                >
                    <List.Item.Meta
                        avatar={<Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=2" />}
                        title={<a href="https://ant.design">{message.author}</a>}
                        description={message.content}
                    />
                </List.Item>
            )}
        />
    );
};
