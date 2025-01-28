import express from 'express';
import bcrypt from 'bcrypt';
import jwt from 'jsonwebtoken';

const app = express();


app.get('/', (req, res) => {
    res.send('It works!');
});

//  -----------    bcrypt    -----------

// const salt = await bcrypt.genSalt(10);   //  Salt here(same salt) gives same hash

app.get('/get-hash/:message', async (req, res) => {
    const message = req.params.message;

    //  Salt here(new salt every time) gives new/diff hash
    const salt = await bcrypt.genSalt(10);
    //                       .hashSync(...)  ->  Synchronous
    const hash = await bcrypt.hash(message, salt);

    res.send(hash);
});


app.get('/check-hash/:message', async (req, res) => {
    const message = req.params.message;
    const savedHash = '$2b$10$E7yp/foErYBZA6zmFTKSrewOgQHtQ6yYbwUVlStvmj63bmtbyEI9O'; // 'hello' hash

    // the message should be 'hello'
    const isValid = await bcrypt.compare(message, savedHash);
    res.send(isValid);
})


//  -----------    JWT    -----------    NO Async !!!

const secret = 'SOMESECRETHERE';

//  Generate token
app.get('/generate-jwt/:message', (req, res) => {
    const message = req.params.message;

    const payload = {
        username: 'Pesho',
        age: 20,
        message,
    }

    const token = jwt.sign(payload, secret, { expiresIn: '2h' });

    res.send(token);
})

//  Verify and Decode token
app.get('/verify-jwt/:token', (req, res) => {
    const token = req.params.token;

    try {
        const decodetToken = jwt.verify(token, secret);
        console.log(decodetToken);
        res.send(decodetToken);
    } catch (err) {
        console.log(err.message);
        res.status(404).send('Invalid token!');
    }
});

// -----------
app.listen(5000, () => console.log('Server is listening on http://localhost:5000...'));