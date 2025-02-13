#  JS-Back-End Exam Prep Skeleton

##  Cheat Sheet

1.  Initialize project
 - [ ] `npm init --yes`
 - [ ] Change Module system -> "type": "module",
 - [ ] Nodemon setup ->  `npm i -D nodemon`   
 - [ ] Add dev/start script  ->   "dev": "nodemon src/index.js"  (start)      
 - [ ] Setup debugging  ->  
          v1  -  add config   in launch.json        
          v2  -  "start": "node --watch src/index.js",   in package.json
 
 2.  Express
 - [ ] insatll  ->    `npm i express`           
 - [ ] Set up initial http server         
 - [ ] Add public resources  (images, css...)  !!!
 - [ ] Add static middleware
 - [ ] Add body parser
 - [ ] Add `routes.js` modular router
 - [ ] Add `controllers` Folder with -> `homeController`

 3.  Handlebars
 - [ ] insatll  ->   `npm i express-handlebars`           
 - [ ] Config handlebars as view engine 
 - [ ] Enable mongo documents to be passed to the view
 - [ ] Change view directory
 - [ ] Add `views` folder in src and resources to it
 - [ ] Add home view
 - [ ] Add `layouts` folder with `main.hbs`  layout view
 - [ ] Add `partials` folder

 4.  Database
 - [ ] Install mongoose `npm i mongoose`
 - [ ] Setup db connectnion
 - [ ] Add `User` in a  `models` folder

 5. Register 
 - [ ] Fix navigation links in main
 - [ ] In views Add  `auth` folder with `register.hbs` view
 - [ ] Add `authController.js`
 - [ ] Add register page  GET
 - [ ] Fix register form 
 - [ ] Add POST register action 
 - [ ] Add folder `services` with `authService.js`
 - [ ] Install bcrypt ->  `npm i bcrypt`
 - [ ] Hash password
 - [ ] Check confirmPassword
 - [ ] Check if user exists

 6. Login
 - [ ] Add jsonwebtoken (JWT)  `npm i jsonwebtoken`
 - [ ] Add cookie parser middleware
 - [ ] Add login view 
 - [ ] Add GET login action
 - [ ] Fix login form
 - [ ] Add POST login action
 - [ ] Add login to authService
        - Validate user
        - Validate password
        - Generate token
        - Return token as cookie
 - [ ] Autologin on register 
        - folder `utils` with  `tokenUtil.js`  ->  generateToken

 7. Logout
 - [ ] Add GET logout action

 8. Authentication and Authorization
 - [ ] Add cookie parser  `npm i cookie-parser`
 - [ ] Add folder `middlewares` with `authMiddleware.js`
 - [ ] Check if guest
 - [ ] Token verification
 - [ ] Atach user to request
 - [ ] Atach user to handlebars context

 9. Authorization
 - [ ] Add isAuth middleware  /  isGuset  ?
 - [ ] Add route guards authorization

 10. Error Handling
 - [ ] Add notifications
 - [ ] Extract error message
        - add `errorUtil.js` in utils
 - [ ] Add error handling for register
 - [ ] Add error handling for login

 11. Bonus
 - [ ] Dynamic Navigation
 - [ ] Dynamic Titles + set titles from view
 - [ ] Async jsonwebtoken + add types to lib

 12. TempData
 - [ ] install express session `npm i express-session`
 - [ ] config express-session
 - [ ] Add tempData middleware ->  `tempDataMiddleware.js`


##  Adapt Skeleton
 - [ ] - Remove old and paste new styles(css)
 - [ ] Copy all html files in view folder(if duplicates like 404 -> remove)
 - [ ] Extract new layout -> in new home.html 
        - [ ] copy content of new home.html and paste in home.hbs
        - [ ] rename to new home.html to `main.hbs`
        - [ ] in `main.hbs`
            - [ ] fix title
            - [ ] fix navigation
            - [ ] add/fix error container
        - [ ] delete old main and put new main.hbs in layouts
 - [ ] Change DB name in DB setup -> url
 - [ ] Modify login page
        - move to views/auth , rename old, new -> hbs
        - fix 
           - remove all out of main, add title
           - `method="POST"`
           - names   ->  as in `User` model   !!!   
           - href="/auth/register"
           - add values to fields `value="{{user.email}}"`
 - [ ] Modify register page  ->  same as login
        -  Modify `User` if missing username or diff in name/username... and in  `tokenUtil`  !!!
               ->  Should be same everywhere  name/username...
        -  rePassword/confirmPassword has to match with `authService`
        -  add values to fields `value="{{user.name}}"` , `value="{{user.email}}"`
 

##  Implement solution

1. Add Models
   - modelSchema -> const deviceSchema = new Schema({ })
   - relations

2. Add Model Controller  -> diviceController.js   
   - use controller in routes.js
   - fix 

3. Create
   - move and rename create.html
      - add title
      - method="POST"
      - fix names
      - fix href="/ /create" in main.hbs  
   - GET create 
   - POST create
      - Check if logged user ->  isAuth 
      - Get data from req.body;
      - Get user Id
      - Call service 
      - Catch error and return response with kept data and error message
      - Redirect to  

4. Home / Catalog  (3)   
   - Fix home view   
   - Get last 3
      - ?  with timestamp in Schema

5. Catalog
   - Fix  view      
   - Get all items   
   - Any  'IF' logic... 
   - Render      

6. Details       
   - Get item id
   - Get item by the id
   - Check if user isOwner
   - hasPreferred ?
   - fix view
   - render view

7. Prefer
   - Get deviceId   
   - Get user id
   - Call service to prefer
      - Check if owner
      - Check if already prefered
      - add to preferredList
      - device.save();
   - redirect

8. Delete
   - Get deviceId   
   - Get user id
   - Call service to remove
      - Check if owner
      - Delete 
   - redirect
            
9. Edit 
   / GET
      - Get deviceId 
      - Get device               
      - Check if owner   -> error + redirect
      - render EDIT page

10. Edit 
    / pOST
      - Get deviceId
      - Get userId
      - Get deviceData
      - Call service
         - get device
         - check if owner
!!!      - update     { runValidators: true }                 !!!
      - Redirect  OR  render same page with Data and Error       

11. About
   - in homeController  -> render('about');     