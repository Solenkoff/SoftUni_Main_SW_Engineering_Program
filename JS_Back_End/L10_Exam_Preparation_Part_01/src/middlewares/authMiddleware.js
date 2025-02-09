import jwt from 'jsonwebtoke';

import { 
    AUTH_COOKIE_NAME, 
    JWT_SECRET
} from '../config.js';

export const auth = (req, res, next) => {
    const token = req.cookie[AUTH_COOKIE_NAME];

    if(!token){
        return next();
    }

    try {
        const decodedToken = jwt.vrify(token, JWT_SECRET);

        next();
    } catch (err) {
        res.clearCookie(AUTH_COOKIE_NAME);
        res.redirect('/auth/login');
    }
}