import { Router } from "express";
import deviceService from "../services/deviceService.js";
import { isAuth } from "../middlewares/authMiddleware.js";

const homeController = Router();


homeController.get('/', async (req, res) => {

    const latestDevice = await deviceService.getLatest();
    res.render('home', { devices: latestDevice });
});


homeController.get('/about', async (req, res) => {
    res.render('about');
});

homeController.get('/profile', isAuth, async (req, res) => {
    res.render('profile', {
        ownDevices,
        preferredDevices
    });  
});


export default homeController; 