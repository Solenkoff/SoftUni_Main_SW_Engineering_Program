import express from 'express';
import mongoose from 'mongoose';
import handlbars from 'express-handlebars';


import routes from './routes.js';
    

const app = express();
const port = 3000;


//  Db setup
try {
    //  TODO: Change DB name
    const url = 'mongodb://localhost:27017/techstore';   
    await mongoose.connect(url);

    console.log('DB Connected!');
} catch (err) {
    console.error('Cannot connect to DB!');
    console.log(err.message);
} 

//  Handlebars setup
app.engine('hbs', handlbars.engine({
    extname: 'hbs',
}))

app.set('view engine', 'hbs');
//  may use   |  import path from 'path';
//            |  app.set('views', path.resolve('./src/views'));  
app.set('views', './src/views');  

//  Express setup
app.use(express.static('src/public'));   //  from root dir
app.use(express.urlencoded({extended: false}));
app.use(routes);



app.listen(port, () => console.log('Server is listening on http://localhost:3000...'));     