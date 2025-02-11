import { Router } from 'express';

const deviceController = Router();

deviceController.get('/create', (req, res) => {
    res.render('devices/create');

    res.end();
});

export default deviceController;