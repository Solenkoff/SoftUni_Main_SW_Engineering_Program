import Disaster from "../models/Disaster.js";
  

export const getAll = (filter = {}) => {
    let query = Disaster.find({});


    return query;
};

export const create = (disasterData, userId) => Disaster.create({ ...disasterData, owner: userId });


const disasterService = {
    getAll,
    create,
};

export default disasterService; 