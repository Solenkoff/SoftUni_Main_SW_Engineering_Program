import Disaster from "../models/Disaster.js";
  

export const getAll = (filter = {}) => {
    let query = Disaster.find({});

    if (filter.name) {
        query = query.find({ name: { $regex: filter.name, $options: 'i' }});
        
    }

    if (filter.typeDisaster) {
        query = query.find({ typeDisaster: filter.typeDisaster });
    }

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

export const updateOne = async (disasterId, userId, disasterData) => {
    const disaster = await getOne(disasterId);

    if (!disaster.owner.equals(userId)) {
        throw new Error('Only owner can  edit their event post!');
    }

    return Disaster.findByIdAndUpdate(disasterId, disasterData, { runValidators: true });
}


const disasterService = {
    getAll,
    create,
    getOne,
    interest,
    remove,
    updateOne
};

export default disasterService; 