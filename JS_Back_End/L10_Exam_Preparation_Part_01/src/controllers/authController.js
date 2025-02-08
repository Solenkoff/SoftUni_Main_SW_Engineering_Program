import { Router } from "express";
import authService from "../services/authService.js";

const authController = Router();


});

authController.post('/register', (req, res) => {
    const userData = req.body;

    authService.register(userData);


    res.redirect('/auth/login');
});


export default authController;