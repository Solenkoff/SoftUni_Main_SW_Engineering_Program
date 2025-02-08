import bcrypt from 'bcrypt';

import User from '../models/User.js';
import { generateToken } from '../utils/tokenUtil.js';

 
export const register = async (userData) => {
    if(userData.password !== userData.confirmPassword){
        throw new Error('Password missmatch!');
    }
       
    const user = await User.findOne({email: userData.email}).select({_id: true});
    if(user){
        throw new Error('User already exists!');
    }

    return User.create(userData); 
    const createdUser = await User.create(userData); 

    const token = generateToken(createdUser);

    return token;
};


 
const authService = {
    register
    register,
};

export default authService; 