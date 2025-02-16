import { Router } from 'express';

import disasterService from '../services/disasterService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';


const disasterController = Router();


disasterController.get('/create', isAuth, (req, res) => {
    const disasterTypesData = getDisasterTypesViewData();

    res.render('disasters/create', { disasterTypes: disasterTypesData });
});

disasterController.post('/create', isAuth, async (req, res) => {
    const disasterData = req.body;
    const userId = req.user.id;

    try {
        await disasterService.create(disasterData, userId);
        res.redirect('/disasters/catalog');
    } catch (err) {
        const error = getErrorMessage(err);
        const disasterTypesData = getDisasterTypesViewData(disasterData.typeDisaster);

        res.render('disasters/create', { disaster: disasterData, disasterTypes: disasterTypesData, error });
    }
});




function getDisasterTypesViewData(typeDisaster) {
    const disasterTypes = [
        'Wildfire',
        'Flood',
        'Earthquake',
        'Hurricane',
        'Drought',
        'Tsunami',
        'Other'
    ]

    const viewData = disasterTypes.map(type => ({
        value: type,
        label: type,
        selected: typeDisaster === type ? 'selected' : '',
    }));

    return viewData;
}


export default disasterController;       