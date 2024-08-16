import { page } from './lib.js';
import { updateNav } from './util.js';
import { showHome } from './views/home.js';
import { showRegister } from './views/register.js';
import { showLogin } from './views/login.js';
import { logout } from './data/users.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showSearchCatalog } from './views/search.js';


updateNav();

page('/', showHome); 
page('/register', showRegister); 
page('/login', showLogin); 
page('/catalog', showCatalog); 
page('/create', showCreate); 
page('/details/:id', showDetails); 
page('/edit/:id', showEdit); 
page('/search', showSearchCatalog); 

page.start();

document.getElementById('logoutBtn').addEventListener('click', async () => {
    logout();
    updateNav();
    page.redirect('/');
});

