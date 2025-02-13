import Device from '../models/Device.js';


export const getAll = () => Device.find({});
//export const getLatest = () => Device.find({}).sort({_id: 'desc'}).limit(3);
export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const getOne = (deviceId) => Device.findById(deviceId);

export const create = (deviceData, userId) => Device.create({ ...deviceData, owner: userId });

export const prefer = async (deviceId, userId) => {
    const device = await Device.findById(deviceId);

    // TODO:  Check if owner
    if(device.owner.equals(userId)){
        throw new Error('Cannot prefer your own offer!');
    }

    // TODO: Check if already prefered
    if(device.preferredList.includes(userId)){
        throw new Error('You have already preferred this offer!');
    }
    //  if no validation 
    //  return Device.findByIdAndUpdate(deviceId, {$push: {preferredList: userId}});

    device.preferredList.push(userId);

    return device.save();
}
 

const deviceService = {
    getAll,
    getLatest,
    getOne,
    create,
    prefer,
};

export default deviceService; 