import { logout } from './data/users.js';
import { page } from './lib.js';
import { updateNav } from './util.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';
//import { showExampleTemplate } from './views/example.js';

//    TESTing  and delete after all  //

//import * as api from './data/request.js';   // 01 -->  await api.get('/data/events')                  | in the 
//import * as userApi from './data/users.js'; // 02 -->  await userApi.login('peter@abv.bg', '123456')  | Browser Console
//import * as api from './data/events.js'; // 03-->  await api.getAllEvents()

updateNav();

//  IF Middlewear placed here
//page('/', showExampleTemplate);

page('/', showHome); 
page('/catalog', showCatalog); 
page('/login', showLogin); 
page('/register', showRegister); 
page('/create', showCreate); 
page('/catalog/:id', showDetails); 
page('/edit/:id', showEdit); 


page.start();

//  ---  LogOut logic   ---

document.getElementById('logoutBtn').addEventListener('click', async () => {
    logout(); 
    updateNav();
    page.redirect('/');
});
//  ---------------------

//window.api = api;             // 01, 03
//window.userApi = userApi;     // 02 

 