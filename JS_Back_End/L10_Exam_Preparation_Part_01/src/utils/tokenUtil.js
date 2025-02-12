import { JWT_SECRET } from '../config.js';
import jwt from '../lib/jwt.js';


export const generateToken = async (user) => {
    const payload = {
        id: user.id,
        email: user.email,
        username: user.username,
    }
    const token = await jwt.sign(payload, JWT_SECRET, {expiresIn: '2h'});

    return token;
}  