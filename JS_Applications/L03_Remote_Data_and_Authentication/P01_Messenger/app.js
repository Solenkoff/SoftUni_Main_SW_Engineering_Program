function attachEvents() {

    const allMessagesEl = document.getElementById('messages');
    const authorNameEl = document.querySelector('input[name="author"]');
    const messageEl = document.querySelector('input[name="content"]');
    const url = 'http://localhost:3030/jsonstore/messenger';

    const SendBtn = document.getElementById('submit').addEventListener('click', onSubmit);
    const refreshBtn = document.getElementById('refresh').addEventListener('click', onRefresh);

    async function onSubmit(e) {
        e.preventDefault();

        const author = authorNameEl.value;
        const content = messageEl.value;
        
        try {
            const request = await fetch(url, {
                method: 'post',
                headers: { 'Content-type': 'application-json' },
                body: JSON.stringify({ author, content })
                // {
                //     author: authorNameEl.value,
                //     content: messageEl.value
                // }    
            });

            if (!request.ok) {
                const err = await request.json();
                throw new Error(err.message);
            }
        } catch (error) {
            alert(`Error: ${error.message}`);
        }

        authorNameEl.value = '';
        messageEl.value = '';
    }

    async function onRefresh(e) {
        e.preventDefault();

        try {
            const response = await fetch(url);
            const data = await response.json();

            if (response.status != 200) {
                const error = 'Content not available!';
                throw new Error(error)
            }

            renderMessages(Object.values(data));

        } catch (error) {
            alert(error.message);
        }

    }

    function renderMessages(messages) {
        const messagesText = messages.map(m => `${m.author}: ${m.content}`).join('\n');
        allMessagesEl.textContent = messagesText;
    }
}

attachEvents();