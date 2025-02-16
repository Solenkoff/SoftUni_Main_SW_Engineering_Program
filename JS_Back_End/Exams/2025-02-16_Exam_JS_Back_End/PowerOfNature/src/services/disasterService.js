import Disaster from "../models/Disaster.js";
  

export const create = (disasterData, userId) => Disaster.create({ ...disasterData, owner: userId });


const disasterService = {
    create,
};

export default disasterService; 