import express from 'express';
import handlebars from 'express-handlebars';
import mongoose from 'mongoose';

import routes from './routes.js';
import showRatingHelper from './helpers/rating-helper.js';

const app = express();
const port = 5000;

//  db configuration
 try {
    const uri = 'mongodb://127.0.0.1:27017/magic-movie'
    await mongoose.connect(uri);

    console.log('DB connected successfully!');
 } catch (err) {
    console.log('Cannot connect to DB!');
    console.log(err.message);
 }


//  handlebars configuration
app.engine('hbs', handlebars.engine({
    extname: 'hbs',
    helpers: {
        showRating: showRatingHelper
    }
}));
app.set('view engine', 'hbs');
app.set('views', './src/views');

//  express configuration
app.use('/static', express.static('src/public'));
app.use(express.urlencoded({extended: false}));    //  Get Express to parse form data

//  set up routes
app.use(routes);

//  start server
app.listen(port, () => console.log('Server is listening on http://localhost:5000...'));