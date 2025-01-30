import express from 'express';
import expressSession from 'express-session';

const app = express();

app.use(expressSession({
    secret: 'THISISMYSECRET',
    resave: false,
    saveUninitialized: false,
    cookie: { secure: false }
}));

   
app.get('/', (req, res) => {
    res.send('It works!');
});


app.get('/set-session-data/:name', ( req, res ) => {
    req.session.name = req.params.name;
    req.session.age = 20;

    res.end();
});

app.get('/get-session-data', (req, res) => {
    console.log(req.session);
    res.send(req.session.name);

    res.end();
})



// -----------
app.listen(5000, () => console.log('Server is listening on http://localhost:5000...'));