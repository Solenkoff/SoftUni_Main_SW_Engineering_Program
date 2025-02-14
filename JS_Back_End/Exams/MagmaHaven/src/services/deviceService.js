import Device from '../models/Device.js';
  

export const getAll = (filter = {}) => {
    let query = Device.find({});
    
    if(filter.owner){
        query = query.find({ owner: filter.owner });
    }

    if(filter.preferredBy){
        query = query.find({preferredList: filter.preferredBy });
        //query = query.in('preferredList', filter.preferredBy );
    }

    return query;
};

//export const getLatest = () => Device.find({}).sort({_id: 'desc'}).limit(3);
export const getLatest = () => getAll().sort({ createdAt: 'desc' }).limit(3);

export const getOne = (deviceId) => Device.findById(deviceId);

export const create = (deviceData, userId) => Device.create({ ...deviceData, owner: userId });

export const prefer = async (deviceId, userId) => {
    const device = await Device.findById(deviceId);

    // TODO:  Check if owner
    if (device.owner.equals(userId)) {
        throw new Error('Cannot prefer your own offer!');
    }

    // TODO: Check if already prefered
    if (device.preferredList.includes(userId)) {
        throw new Error('You have already preferred this offer!');
    }
    //  if no validation 
    //  return Device.findByIdAndUpdate(deviceId, {$push: {preferredList: userId}});

    device.preferredList.push(userId);

    return device.save();
}

export const remove = async (deviceId, userId) => {
    const device = await Device.findById(deviceId);
    if (!device.owner.equals(userId)) {
        throw new Error('Only owner can delete their offer!');
    }

    return Device.findByIdAndDelete(deviceId);
}

export const updateOne = async (deviceId, userId, deviceData) => {
    const device = await getOne(deviceId);

    if (!device.owner.equals(userId)) {
        throw new Error('Only owner can  edit their offer!');
    }

    return Device.findByIdAndUpdate(deviceId, deviceData, { runValidators: true });   //*  !!!
}


const deviceService = {
    getAll,
    getLatest,
    getOne,
    create,
    prefer,
    remove,
    updateOne,
};

export default deviceService; 