import { clearUserData, setUserData } from '../util.js';
import { post, get } from './request.js';

//  TODO -  Adapat user profile to exam requirements (identity, extra props, etc.)

const endpoints = {
    login: '/users/login',
    register: '/users/register',
    logout: '/users/logout'
};

export async function login(email, password){
    const result = await post(endpoints.login, { email, password }); 

    setUserData(result);
}

export async function register(email, password){
    const result = await post(endpoints.register, { email, password }); 

    setUserData(result);
}

export async function logout(){
    const promise = get(endpoints.logout);   //  Important order of execution

    clearUserData();
    await promise;
}
