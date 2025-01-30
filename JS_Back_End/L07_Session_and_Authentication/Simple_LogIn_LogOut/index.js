import express from 'express';
import cookieParser from 'cookie-parser';
import bcrypt from 'bcrypt';
import jwt from 'jsonwebtoken';

const app = express();

app.use(express.urlencoded({extended: false}));   //  !!!  Filter url data to get only the fields
app.use(cookieParser());


app.get('/', (req, res) => {
    res.send('It works!');
});
 
const users = [];
const secret = 'SOMESECRETHERE';

app.get('/register', (req, res) => {
    res.send(`
    <form method="POST">
        <div>
            <label for="username">Username</label>
            <input type="text" id="username" name="username" />
        </div>
    
        <div>
            <label for="password">Password</label>
            <input type="password" id="password" name="password" />
        </div>
        <div>
            <input type="submit" value="Register">
        </div>
    </form>
    `);
});

app.post('/register', async (req, res) => {
    const { username, password } = req.body;    //  urlencoded({extended: flase})
   
    // Hash password
    const salt = await bcrypt.genSalt(10);
    const hash = await bcrypt.hash(password, salt);

    // TODO: vlidate whether user exists

    // Save user data
    users.push({
        username,
        password: hash
    })

    console.log(users);

    // Redirect login
    res.redirect('/login');
});

app.get('/login', (req, res) => {
    res.send(`
        <form method="POST">
            <div>
                <label for="username">Username</label>
                <input type="text" id="username" name="username" />
            </div>
        
            <div>
                <label for="password">Password</label>
                <input type="password" id="password" name="password" />
            </div>
            <div>
                <input type="submit" value="Login">
            </div>
        </form>
        `);
});

app.post('/login', async (req, res) => {
    const { username, password } = req.body; 
    
    const user = users.find(user => user.username === username);

    //  Check whether user exists
    if(!user){
        return res.send('Invalid user!');
    }

    //  check whether password is valid
    const isValid = await bcrypt.compare(password, user.password);
    if(!isValid){
        return res.send('Invalid password!');
    }

    //  Issue token when authenticated
    const token = jwt.sign({username}, secret, {expiresIn: '2h'});

    //  Include token into a cookie
    res.cookie('auth', token); 

    res.end('You are loged in!');
}); 

// Make an authorized request
app.get('/profile', async (req, res) => {
    const token = req.cookies['auth'];

    if(!token){
        return res.status(401).send('Unauthorized!');
    }

    try {
        const decodedToken = jwt.verify(token, secret);

        res.send(`
            <h1>Profile Page | ${decodedToken.username}</h1>
        `)
    } catch (err) {
        return res.status(401).send('Invalid token!');
    }
 });


// -----------
app.listen(5000, () => console.log('Server is listening on http://localhost:5000...'));