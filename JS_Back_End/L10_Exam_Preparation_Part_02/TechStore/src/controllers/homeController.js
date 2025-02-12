import { Router } from "express";
import deviceService from "../services/deviceService.js";

const homeController = Router();


homeController.get('/', async (req, res) => {

    const latestDevice = await deviceService.getLatest();
    res.render('home', { devices: latestDevice });
})

export default homeController; 