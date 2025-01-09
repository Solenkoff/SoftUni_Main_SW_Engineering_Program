import http from 'http';

import homePage from './views/home/index.html.js';

const server = http.createServer((req, res) => {

    res.writeHead(200, {
        'content-type': 'text/html',
    })

    res.write(homePage);
    res.end();
});

server.listen(5000);
console.log('Server is listening on http://localhost:5000...');