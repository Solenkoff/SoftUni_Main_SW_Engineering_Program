import jwt from 'jsonwebtoken';

const SECRET = process.env.JWT_SECRET || 'BasicSecret';

export const authMiddleware = () => (req, res, next) => {
    const token = req.cookies['auth'];

    if(!token){
        return next();
    }

    try {
        const decodedToken = jwt.verify(token, SECRET);

        req.user = decodedToken;
        res.locals.user = decodedToken;
        // const isAuthenticated = true;   //  instead of res.locals.user

        next();
    } catch (err) {
        res.setError('Invalid authentication!')
        res.clearCookie('auth');
        res.redirect('/auth/login');
    }

};         


export const isAuth = (req, res, next) => {
    if(!req.user){
        res.setError('You must be loged in to use this functionality!')
        res.redirect('/auth/login');
    }

    next();
}