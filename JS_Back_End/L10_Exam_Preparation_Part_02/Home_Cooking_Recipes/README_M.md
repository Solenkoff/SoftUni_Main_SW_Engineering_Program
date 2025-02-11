#  JS-Back-End Exam Prep Skeleton

##  Cheat Sheet

1.  Initialize project
 - [x] `npm init --yes`
 - [x] Change Module system -> "type": "module",
 - [x] Nodemon setup ->  `npm i -D nodemon`   
 - [x] Add dev/start script  ->   "dev": "nodemon src/index.js"  (start)      
 - [x] Setup debugging  ->  
          v1  -  add config   in launch.json        
          v2  -  "start": "node --watch src/index.js",   in package.json
 
 2.  Express
 - [x] insatll  ->    `npm i express`           
 - [x] Set up initial http server         
 - [x] Add public resources  (images, css...)  !!!
 - [x] Add static middleware
 - [x] Add body parser
 - [x] Add `routes.js` modular router
 - [x] Add `controllers` Folder with -> `homeController`

 3.  Handlebars
 - [x] insatll  ->   `npm i express-handlebars`           
 - [x] Config handlebars as view engine 
 - [x] Enable mongo documents to be passed to the view
 - [x] Change view directory
 - [x] Add `views` folder in src and resources to it
 - [x] Add home view
 - [x] Add `layouts` folder with `main.hbs`  layout view
 - [x] Add `partials` folder

 4.  Database
 - [x] Install mongoose `npm i mongoose`
 - [x] Setup db connectnion
 - [x] Add `User` in a  `models` folder

 5. Register 
 - [x] Fix navigation links in main
 - [x] In views Add  `auth` folder with `register.hbs` view
 - [x] Add `authController.js`
 - [x] Add register page  GET
 - [x] Fix register form 
 - [x] Add POST register action 
 - [x] Add folder `services` with `authService.js`
 - [x] Install bcrypt ->  `npm i bcrypt`
 - [x] Hash password
 - [x] Check confirmPassword
 - [x] Check if user exists

 6. Login
 - [x] Add jsonwebtoken (JWT)  `npm i jsonwebtoken`
 - [x] Add cookie parser middleware
 - [x] Add login view 
 - [x] Add GET login action
 - [x] Fix login form
 - [x] Add POST login action
 - [x] Add login to authService
        - Validate user
        - Validate password
        - Generate token
        - Return token as cookie
 - [x] Autologin on register 
        - folder `utils` with  `tokenUtil.js`  ->  generateToken

 7. Logout
 - [x] Add GET logout action

 8. Authentication and Authorization
 - [x] Add cookie parser  `npm i cookie-parser`
  - [x] Add folder `middlewares` with `authMiddleware.js`
 - [x] Check if guest
 - [x] Token verification
 - [x] Atach user to request
 - [x] Atach user to handlebars context

 9. Authorization
 - [x] Add isAuth middleware
 - [x] Add route guards authorization

 10. Error Handling
 - [x] Add notifications
 - [x] Extract error message
        - add `errorUtil.js` in utils
 - [x] Add error handling for register
 - [x] Add error handling for login

 11. Bonus
 - [x] Dynamic Navigation
 - [x] Dynamic Titles + set titles from view
 - [x] Async jsonwebtoken + add types to lib

 12. TempData
 - [x] install express session `npm i express-session`
 - [x] config express-session
 - [x] Add tempData middleware ->  `tempDataMiddleware.js`


##  Adapt Skeleton
 - [x] - Remove old and paste new styles(css)
 - [x] Copy all html files in view folder(if duplicates like 404 -> remove)
 - [x] Extract new layout -> in new home.html 
        - [x] copy content of new home.html and paste in home.hbs
        - [x] rename to new home.html to `main.hbs`
        - [x] in `main.hbs`
            - [x] fix title
            - [x] fix navigation
            - [x] add/fix error container
        - [x] delete old main and put new main.hbs in layouts
 - [x] Change DB name in DB setup -> url
 - [x] Modify login page
        - move to views/auth , rename old, new -> hbs
        - fix 
           - remove all out of main, add title
           - `method="POST"`
           - names   ->  as in `User` model   !!!   
           - href="/auth/register"
           - add values to fields `value="{{user.email}}"`
 - [x] Modify register page  ->  same as login
        -  Modify `User` if missing username or diff in name/username... and in  `tokenUtil`  
               ->  Should be same everywhere  name/username...
        -  rePassword/confirmPassword has to match with `authService`
        -  add values to fields `value="{{user.name}}"` , `value="{{user.email}}"`
 - [x]