import express from 'express';
import mongoose from 'mongoose';
import handlbars from 'express-handlebars';
import cookieParser from 'cookie-parser';
import expressSession from 'express-session';

import routes from './routes.js';
import { auth } from './middlewares/authMiddleware.js';
import { setTitle } from './utils/pageTitleUtil.js';
import { tempData } from './middlewares/tempDataMiddleware.js';


const app = express();
const port = 3000;


try {
    const url = 'mongodb://localhost:27017/magmaHaven';
    await mongoose.connect(url);

    console.log('DB Connected!');
} catch (err) {
    console.error('Cannot connect to DB!');
    console.log(err.message);
}

app.engine('hbs', handlbars.engine({
    extname: 'hbs',
    runtimeOptions: {
        allowProtoPropertiesByDefault: true,
    },
    helpers: {
        setTitle
    }
}));

app.set('view engine', 'hbs');
app.set('views', './src/views');

app.use(express.static('src/public'));   
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(expressSession({
    secret: '*slnlsnLSlLlnsl***03jpjSIDj90034j4twSJ',
    resave: false,
    saveUninitialized: false,
    cookie: { 
        secure: false, 
        httpOnly: true 
    }
}));
app.use(auth);
app.use(tempData);
app.use(routes);


app.listen(port, () => console.log('Server is listening on http://localhost:3000...'));     