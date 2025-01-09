import http from 'http';

import siteCss from './content/styles/site.css.js';
import homePage from './views/home/index.html.js';

const server = http.createServer((req, res) => {

    // Load assets
    if (req.url === '/styles/site.css') {
        res.writeHead(200, {
            'content-type': 'text/css',
        });

        res.write(siteCss);

        return res.end();
    }
    
    res.writeHead(200, {
        'content-type': 'text/html',
    })

    res.write(homePage);
    res.end();
});

server.listen(5000);
console.log('Server is listening on http://localhost:5000...');