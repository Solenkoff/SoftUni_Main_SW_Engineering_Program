import express from 'express';
import routes from './routes.js';
const app = express();
//  Express setup
app.use(express.static('src/public'));   //  from root dir
app.use(express.urlencoded({extended: false}));
app.listen(port, () => console.log('Server is listening on http://localhost:3000...'));     