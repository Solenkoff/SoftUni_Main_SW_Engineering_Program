Create project framework 

[] lib.js Rendering and other lib utils   | in src                L17 00:43:40
        - setting the root element     

[] app.js  with router init               | in src
        + exapleTemplate to verifi that it works     L17 00:47:00

[] 'request' - Requester modul            | in src/data
        + testing it with:  import * as api from '/data/request.js';   |                  01:03:15
                            window.api = api;                          |  in app.js
                            await api.get('/data/events')              |  in the Browser Console
                              |              ^-- depending on the REST server
                               \ -->  repeating the request

[] 'users' - User Api module -> Login,Logout,Register    | in src/data
        + testing it with:  import * as userApi from '/data/users.js';   |                01:03:15
                            window.userApi = userApi;                             |  in app.js
                            await userApi.register('peter@abv.bg', '123456')      |  in the Browser Console 
                                    ...check LocalStorage for new user          
                            await userApi.login('peter@abv.bg', '123456')  
                                    ...check LocalStorage for the user
                            await userApi.logout()              
                              |         ...check LocalStorage for new user
                               \ -->  repeating the request

[] util.js - Local storage, createSubmitHandler and other utilities  | in src
        + example.js  in src/views  to test submitHandler and functionality

             !!!  ToDo guest/user logic for Nav

-------------------
 Copy  src to Project        
-------------------

Implement exam solution

[] Examine Problem Descriptions/ Files / Dependancies / HTML
[] Prepare HTML templates + copy HTML( indexCopy.html )

[] Adapt user Api module ( login, logout, register)
[] Create colection api module with endpoints (Events in this case) in src/data
   [ ] Read All    app.js|03
   [ ] Create
   [ ] Read Details
   [ ] Edit
   [ ] Delete
[ ] Implement views
   [+] Home page                 | 01:59:30
         -  import (html,page)
         -  homeTemplate 
               - fix  href="/catalog"  depending on case
                 if form add @submit=${onLogin...}
         -  func showHome   
         -  page('/', showHome);   in app.js   
   [] Catalog        | 02:02:30
   [] Login          | 02:13:40
   [] Register       | 02:18:20      !!!  Error for wrong pass -> 'Passwords don't match'
   [] Logout
        -  href="javascript:void(0)"  +  id="logoutBtn"   | 02:25:30
        -  select el./ async() / logout() / redirect    in app.js
   [] Navigation
        -  change href's in Nav ex # => /login
        -  guest/user logic for Nav  func updateNav()   in util.js 
        -  updateNav()   in app.js
   [] Create form    | 02:39:45
   [] Details        | 02:45:00
   [] Edit Form
   [] Delete         | 03:03:00
        + confirm if needed  -> const choice = confirm('Are you sure?);
   [] Bonus          | 03:08:00