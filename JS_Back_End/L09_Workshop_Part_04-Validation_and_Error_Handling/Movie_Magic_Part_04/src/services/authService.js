import User from "../models/User.js";
import bcrypt from 'bcrypt';
import jwt from 'jsonwebtoken';

const SECRET = process.env.JWT_SECRET || 'BasicSecret';

export default {
    async register(userData) {
        //  Check if password match repassword   =>  Done in Model with virtual property
        // if(userData.password !== userData.rePassword){
        //     throw new Error('Password missmatch!');
        // }

        //  Check if email exists
        const userCount = await User.countDocuments({ email: userData.email });
        if (userCount > 0) {
            throw new Error('Email already exists!');
        }

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