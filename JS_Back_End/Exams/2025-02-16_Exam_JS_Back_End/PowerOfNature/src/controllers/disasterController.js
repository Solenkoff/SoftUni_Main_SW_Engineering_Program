import { Router } from 'express';

import disasterService from '../services/disasterService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';


const disasterController = Router();


disasterController.get('/catalog', async (req, res) => {
    const disasters = await disasterService.getAll();

    res.render('disasters/catalog', { disasters }); 
}) 


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

disasterController.get('/:disasterId/details', async (req, res) => {
    const disasterId = req.params.disasterId;
    const disaster = await disasterService.getOne(disasterId);

    const isOwner = disaster.owner.equals(req.user?.id);
    const isInterested = disaster.interestedList.includes(req.user?.id);
    const interestCount = disaster.interestedList.length;

    res.render('disasters/details', { disaster, isOwner, isInterested, interestCount});
});

disasterController.get('/:disasterId/interest', isAuth, async (req, res) => {
    const disasterId = req.params.disasterId;
    const userId = req.user.id;

    try {
        await disasterService.interest(disasterId, userId);
    } catch (err) {
        res.setError(getErrorMessage(err));
    }

    res.redirect(`/disasters/${disasterId}/details`);
});

disasterController.get('/:disasterId/delete', isAuth, async (req, res) => {
    const disasterId = req.params.disasterId;
    const userId = req.user.id;

    try {
        await disasterService.remove(disasterId, userId);

        res.redirect('/disasters/catalog');
    } catch (err) {
        res.setError(getErrorMessage(err));
        res.redirect(`/disasters/${disasterId}/details`);
    }

});

disasterController.get('/:disasterId/edit', isAuth, async (req, res) => {
    const disasterId = req.params.disasterId;
    const disaster = await disasterService.getOne(disasterId);

    if (!disaster.owner.equals(req.user.id)) {
        res.setError('Only owners can edit their event post!');
        return res.redirect(`/disasters/${disasterId}/details`);
    }

    const currDisasterType = disaster.typeDisaster;
    const disasterTypesData = getDisasterTypesViewData(currDisasterType);

    res.render('disasters/edit', { disaster, disasterTypes: disasterTypesData });
});

disasterController.post('/:disasterId/edit', isAuth, async (req, res) => {
    const disasterId = req.params.disasterId;
    const userId = req.user.id;
    const disasterData = req.body;

    try {
        await disasterService.updateOne(disasterId, userId, disasterData);
        return res.redirect(`/disasters/${disasterId}/details`);
    } catch (err) {
        res.render('disasters/edit', { disaster: disasterData, error: getErrorMessage(err) });
    }

});

disasterController.get('/search', async (req, res) => {
    const filter = req.query;
    const disasters = await disasterService.getAll(filter);

    const disasterTypesData = getDisasterTypesViewData(filter.typeDisaster);

    res.render('disasters/search', { disasters, filter, disasterTypes: disasterTypesData });
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