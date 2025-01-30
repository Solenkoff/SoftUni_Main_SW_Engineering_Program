import express from 'express';
import cookieParser from 'cookie-parser';

const app = express();

app.use(cookieParser());


app.get('/', (req, res) => {
    res.send('It works!');
});


// ------   Set/Get Cookie Manually   -------

app.get('/set-cookie-manually', (req, res) => {
    //  HTTP 
    // res.writeHead(200, {
    //     'Set-Cookie': 'username=Pesho'
    // });

    //  Express
    res.setHeader('Set-Cookie', 'username=Gosho');

    res.end();
});

app.get('/get-cookie-manually', (req, res) => {
    //  Express
    const cookie = req.header('Cookie');

    console.log(cookie);

    res.end();
})


// ------   Usind Cookie Parser Library   -------

app.get('/set-cookie', (req, res) => {
    // res.cookie('username', 'Stamat');      //  Not  httpOnly

    res.cookie('username', 'Stamat', {        //       httpOnly
        httpOnly: true,
    });
    
    res.end();
});

app.get('/get-cookie', ( req, res ) => {
    const cookieValue = req.cookies['username'];

    console.log(cookieValue);

    res.end();
})


// -----------
app.listen(5000, () => console.log('Server is listening on http://localhost:5000...'));