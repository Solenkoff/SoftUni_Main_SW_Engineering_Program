import { Router } from 'express';

import deviceService from '../services/deviceService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { isOwner } from '../middlewares/isOwnerMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';

const deviceController = Router();


deviceController.get('/catalog', async (req, res) => {
    const devices = await deviceService.getAll();

    res.render('devices/catalog', { devices });
})

deviceController.get('/create', isAuth, (req, res) => {
    res.render('devices/create');

});

deviceController.post('/create', isAuth, async (req, res) => {   // Check if logged user
    const deviceData = req.body;     // Get data from body
    const userId = req.user.id;      // Get user Id

    try {
        await deviceService.create(deviceData, userId);     // Call service 
        res.redirect('/devices/catalog');                           //redirect to catalog
    } catch (err) {                                         // Catch error and return response with kept data and error message
        res.render('devices/create', { device: deviceData, error: getErrorMessage(err) });
    }
});

deviceController.get('/:deviceId/details', async (req, res) => {
    const deviceId = req.params.deviceId;
    const device = await deviceService.getOne(deviceId);

    //const isOwner = req.user && req.user.id === device.owner.toString(); 
    const isOwner = device.owner.equals(req.user?.id);
    const hasPreferred = device.preferredList.includes(req.user?.id);

    res.render('devices/details', { device, isOwner, hasPreferred });
});

deviceController.get('/:deviceId/prefer', isAuth, async (req, res) => {
    const deviceId = req.params.deviceId;
    const userId = req.user.id;

    try {
        await deviceService.prefer(deviceId, userId);
    } catch (err) {
        res.setError(getErrorMessage(err));
    }

    res.redirect(`/devices/${deviceId}/details`);
});

deviceController.get('/:deviceId/delete', isAuth, async (req, res) => {
    const deviceId = req.params.deviceId;
    const userId = req.user.id;

    try {
        await deviceService.remove(deviceId, userId);

        res.redirect('/devices/catalog');
    } catch (err) {
        res.setError(getErrorMessage(err));
        res.redirect(`/devices/${deviceId}/details`);
    }

});

deviceController.get('/:deviceId/edit', isAuth, async (req, res) => {
    //  with isOwner middleware -> just pass the device through req
    //  res.render('devices/edit', { device: req.device });

    const deviceId = req.params.deviceId;
    const device = await deviceService.getOne(deviceId);

    if (!device.owner.equals(req.user.id)) {
        res.setError('Only owners can edit their offer!');
        return res.redirect(`/devices/${deviceId}/details`);
    }

    res.render('devices/edit', { device });
});

deviceController.post('/:deviceId/edit', isAuth, async (req, res) => {
    const deviceId = req.params.deviceId;
    const userId = req.user.id;
    const deviceData = req.body;

    try {
        await deviceService.updateOne(deviceId, userId, deviceData);
        return res.redirect(`/devices/${deviceId}/details`);
    } catch (err) {
        res.render('devices/edit', { device: deviceData, error: getErrorMessage(err) });
    }

});

export default deviceController;       