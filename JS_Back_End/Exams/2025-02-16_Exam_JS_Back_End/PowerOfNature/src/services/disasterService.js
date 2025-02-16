import Disaster from "../models/Disaster.js";
  

export const getAll = (filter = {}) => {
    let query = Disaster.find({});


    return query;
};

export const create = (disasterData, userId) => Disaster.create({ ...disasterData, owner: userId });

export const getOne = (disasterId) => Disaster.findById(disasterId);



const disasterService = {
    getAll,
    create,
    getOne,
};

export default disasterService; 