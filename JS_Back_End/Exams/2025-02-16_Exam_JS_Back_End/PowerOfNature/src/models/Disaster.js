import { Schema, model, Types } from 'mongoose';

const disasterSchema = new Schema({
    name: {
        type: String,
        required: true,
    },
    typeDisaster: {
        type: String,
        required: true,
        enum: [
            'Wildfire', 
            'Flood', 
            'Earthquake', 
            'Hurricane', 
            'Drought', 
            'Tsunami', 
            'Other'
        ],
    },
    eventYear: {
        type: Number,
        required: true,
    },
    location: {
        type: String,
        required: true,
    },
    image: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
    },
    interestedList : [{
        type: Types.ObjectId,
        ref: 'User'
    }],
    owner: {
        type: Types.ObjectId,
        ref: 'User'
    }
});

const Disaster = model('Disaster', disasterSchema);

export default Disaster;

 