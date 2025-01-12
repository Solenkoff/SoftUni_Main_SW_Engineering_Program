import http from 'http';
import { v4 as uuid } from 'uuid';
import fs from 'fs/promises';

import siteCss from './content/styles/site.css.js';
import homePage from './views/home/index.html.js';
import addBreedPage from './views/addBreed.html.js';
import addCatPage from './views/addCat.html.js';
import editCatPage from './views/editCat.html.js';

let cats = [];
let breeds = [];

initCats();
initBreeds();

const server = http.createServer((req, res) => {
    if (req.method === 'POST') {
        let body = '';

        req.on('data', chunk => {
            body += chunk.toString();
        });

        req.on('end', () => {
            const data = new URLSearchParams(body);
            console.log(data.entries());

            if (req.url === '/cats/add-cat') {

                cats.push({
                    id: uuid(),
                    ...Object.fromEntries(data.entries()),
                });

                saveCats();

            } else if (req.url === '/cats/add-breed') {

                const newBreed = Object.fromEntries(data.entries());
                const newBreedName = newBreed.breed;

                const currBreeds = breeds.map(b => b.breed);

                if (!currBreeds.includes(newBreedName)) {
                    breeds.push(newBreed);

                    saveBreed();
                }

            }else if (req.url.startsWith('/cat/edit')) {

                const id = req.url.split('/cat/edit/')[1];
        
                cats = cats.filter(c => c.id !== id);

                cats.push({
                    id: uuid(),
                    ...Object.fromEntries(data.entries()),
                });

                saveCats();
            }

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

    if (req.url.startsWith('/cat/edit')) {

        const id = req.url.split('/cat/edit/')[1];

        const cat = cats.find(c => c.id == id);

        res.write(editCatPage(cat, breeds));

        return res.end();
    }else if (req.url.startsWith('/cat/delete')) {

        const id = req.url.split('/cat/edit/')[1];

        cats = cats.filter(c => c.id !== id);

        saveCats();

        res.writeHead('302', {
            'location': '/',
        })

        return res.end();
    }


    switch (req.url) {

        case '/':
            res.write(homePage(cats));
            break;
        case '/cats/add-breed':
            res.write(addBreedPage());
            break;
        case '/cats/add-cat':
            res.write(addCatPage(breeds));
            break;
        default:
            res.write('Page Not Found!');
            break;
    }


    res.end();
});

async function initBreeds() {
    try {
        const breedJson = await fs.readFile('./breed.json', { encoding: 'utf-8' });
        breeds = JSON.parse(breedJson);
    } catch (err) {
        alert('Error: ${err.message}');
    }
}

async function saveBreed() {
    try {
        const breedJson = JSON.stringify(breeds, null, 2);
        await fs.writeFile('./breed.json', breedJson, { encoding: 'utf-8' });
    } catch (err) {

    }
}

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