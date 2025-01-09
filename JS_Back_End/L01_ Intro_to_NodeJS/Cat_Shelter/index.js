import http from 'http';

import siteCss from './content/styles/site.css.js';
import homePage from './views/home/index.html.js';
import addBreedPage from './views/addBreed.html.js';


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

    switch (req.url) {
        case '/':
            res.write(homePage);
            break;
        case '/cats/add-breed':
            res.write(addBreedPage);
            break;
        default:
            res.write('Page Not Found!');
            break;
    }

    res.end();
});

server.listen(5000);
console.log('Server is listening on http://localhost:5000...');