import { Router } from "express";

import homeController from "./controllers/homeController.js";
import authController from "./controllers/authController.js";
//import modelController from "./controllers/modelController.js";


const routes = Router();


routes.use(homeController);
routes.use('/auth', authController);
//routes.use('/model', modelController);
routes.all('*', (req, res) => {
    res.render('404');
});

export default routes;
 