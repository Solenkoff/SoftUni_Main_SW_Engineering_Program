import { Router } from "express";
import authService from "../services/authService.js";
import { AUTH_COOKIE_NAME } from "../../config.js";

const authController = Router();


authController.get('/register',  (req, res) => {
    res.render('auth/register'); 
});

authController.post('/register', async (req, res) => {
    const userData = req.body;

    authService.register(userData);
    const token =  await authService.register(userData);

    res.cookie(AUTH_COOKIE_NAME, token);
    res.redirect('/');
});

    res.redirect('/auth/login');
authController.get('/login', (req, res) => {
    res.render('auth/login');
});


export default authController;