import Device from '../models/Device.js';


export const getAll = () => Device.find({});
//export const getLatest = () => Device.find({}).sort({_id: 'desc'}).limit(3);
export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const create = (deviceData, userId) => Device.create({ ...deviceData, owner: userId });


const deviceService = {
    getAll,
    getLatest,
    create,

};

export default deviceService; 