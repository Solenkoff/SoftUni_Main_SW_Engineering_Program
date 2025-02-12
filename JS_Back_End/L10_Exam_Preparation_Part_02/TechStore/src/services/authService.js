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

    const createdUser = await User.create(userData); 

    const token = generateToken(createdUser);

    return token;
};

export const login = async (email, password) => {
    //Validate user
    const user = await User.findOne({email});
    if(!user){
        throw new Error('Invalid user or email!');
    }
    //Validate password
    const isValidPassword = await bcrypt.compare(password, user.password);
    if(!isValidPassword){
        throw new Error('Invalid user or email!');   
    }

    const token = generateToken(user);

    return token;
}


const authService = {
    register,
    login,
};

export default authService; 