import User from "../models/user.js";
import bcrypt from 'bcrypt';
import jwt from 'jsonwebtoken';

const SECRET = process.env.JWT_SECRET || 'BasicSecret';

export default {
    register(userData) {
        return User.create(userData);
    },
    async login(email, password) {
        const user = await User.findOne({ email });

        if (!user) {
            throw new Error('Invalid email or password!');
        }

        const isValidPassword = await bcrypt.compare(password, user.password);

        if (!isValidPassword) {
            throw new Error('Invalid email or password!');
        }

        const payload = {
            id: user.id,     //  user._id ->  Being document it recognaizes .id as ._id
            email: user.email
        }

        //  TODO: use async option
        const token = jwt.sign(payload, SECRET, { expiresIn: '2h' });

        return token;
    }
} 