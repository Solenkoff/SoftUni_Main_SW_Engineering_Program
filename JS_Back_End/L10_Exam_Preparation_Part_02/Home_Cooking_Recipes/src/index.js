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


//  Db setup
try {
    // TODO: Change DB name
    const url = 'mongodb://localhost:27017/recipes';
    await mongoose.connect(url);

    console.log('DB Connected!');
} catch (err) {
    console.error('Cannot connect to DB!');
    console.log(err.message);
}

//  Handlebars setup
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
//  may use   |  import path from 'path';
//            |  app.set('views', path.resolve('./src/views'));  
app.set('views', './src/views');

//  Express setup
app.use(express.static('src/public'));   //  from root dir
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(expressSession({
    secret: '*86c82de7-2a59-42fb-8167-1aab798ba08b',
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