import Disaster from "../models/Disaster.js";
  

export const getAll = (filter = {}) => {
    let query = Disaster.find({});


    return query;
};

export const create = (disasterData, userId) => Disaster.create({ ...disasterData, owner: userId });

export const getOne = (disasterId) => Disaster.findById(disasterId);

export const interest = async (disasterId, userId) => {
    const disaster = await Disaster.findById(disasterId);

    if (disaster.owner.equals(userId)) {
        throw new Error('Cannot be interested in your own event post!');
    }

    if (disaster.interestedList.includes(userId)) {
        throw new Error('You have already been interested in this event!');
    }

    disaster.interestedList.push(userId);

    return disaster.save();
}

export const remove = async (disasterId, userId) => {
    const disaster = await Disaster.findById(disasterId);

    if (!disaster.owner.equals(userId)) {
        throw new Error('Only owner can delete their event post!');
    }

    return Disaster.findByIdAndDelete(disasterId);
}



const disasterService = {
    getAll,
    create,
    getOne,
    interest,
    remove,
};

export default disasterService; 