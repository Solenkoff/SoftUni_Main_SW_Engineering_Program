import http from 'http';
import { v4 as uuid } from 'uuid';
import fs from 'fs/promises';

import siteCss from './content/styles/site.css.js';
import homePage from './views/home/index.html.js';
import addBreedPage from './views/addBreed.html.js';
import addCatPage from './views/addCat.html.js';

let cats = [];

initCats();

const server = http.createServer((req, res) => {
    if (req.method === 'POST') {
        let body = '';

        req.on('data', chunk => {
            body += chunk.toString();
        });

        req.on('end', () => {
            const data = new URLSearchParams(body);

            cats.push({
                // id: cats.length + 1,    //  Works if there is NO delete cat option
                id: uuid(),
                ...Object.fromEntries(data.entries()),
            });

            saveCats();

            res.writeHead('302', {
                'location': '/',
            })

            res.end();
        });

        return;
    }

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
            console.log(uuid())
            res.write(homePage(cats));
            break;
        case '/cats/add-breed':
            res.write(addBreedPage());
            break;
        case '/cats/add-cat':
            res.write(addCatPage());
            break;
        default:
            res.write('Page Not Found!');
            break;
    }

    res.end();
});

async function initCats() {
    try {
        const catsJson = await fs.readFile('./cats.json', { encoding: 'utf-8' });
        cats = JSON.parse(catsJson);
    } catch (err) {
        alert(`Error: ${err.message}`);
    }

}

async function saveCats() {
    try {
        const catsJson = JSON.stringify(cats, null, 2);
        await fs.writeFile('./cats.json', catsJson, { encoding: 'utf-8' });
    } catch (err) {
        alert(`Error: ${err.message}`);
    }

}

server.listen(5000);
console.log('Server is listening on http://localhost:5000...');