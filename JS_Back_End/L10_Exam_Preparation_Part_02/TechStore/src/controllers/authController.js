import { Router } from "express";

import authService from "../services/authService.js";
import { AUTH_COOKIE_NAME } from "../config.js";
import { isAuth } from "../middlewares/authMiddleware.js";
import { getErrorMessage } from "../utils/errorUtil.js";

const authController = Router();


authController.get('/register', (req, res) => {
    res.render('auth/register');
});

authController.post('/register', async (req, res) => {
    const userData = req.body;

    try {
        const token = await authService.register(userData);

        res.cookie(AUTH_COOKIE_NAME, token, { httpOnly: true });
        res.redirect('/');
    } catch (err) {
        res.render('auth/register', { error: getErrorMessage(err), userData });
    }
});

authController.get('/login', (req, res) => {
    res.render('auth/login');
});

authController.post('/login', async (req, res) => {
    const { email, password } = req.body;

    try {
        const token = await authService.login(email, password);
        res.cookie(AUTH_COOKIE_NAME, token, { httpOnly: true });
        res.redirect('/');
    } catch (err) {
        res.render('auth/login', { 
            error: getErrorMessage(err), 
            userData: { email } 
        });
    }
});

authController.get('/logout', isAuth, (req, res) => {
    res.clearCookie(AUTH_COOKIE_NAME);
    res.redirect('/');
})


export default authController;