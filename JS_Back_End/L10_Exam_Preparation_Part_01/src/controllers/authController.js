import { Router } from "express";
import authService from "../services/authService.js";

const authController = Router();


});

    const userData = req.body;

    authService.register(userData);
    const token =  await authService.register(userData);

    res.cookie(AUTH_COOKIE_NAME, token);
    res.redirect('/');
});

    res.redirect('/auth/login');
});


export default authController;