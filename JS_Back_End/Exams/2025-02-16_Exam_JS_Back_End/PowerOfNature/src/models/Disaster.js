import { Schema, model, Types } from 'mongoose';

const disasterSchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: [2, 'The Name should be at least 2 characters long']
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
        min: [0, 'The Year should be between 0 and 2024'],
        max: [2024, 'The Year should be between 0 and 2024']
    },
    location: {
        type: String,
        required: true,
        minLength: [3, 'The Location should be at least 3 characters long']
    },
    image: {
        type: String,
        required: true,
        validate: [ /^https?:\/\//, 'The Disaster Image should start with http:// or https://' ]
    },
    description: {
        type: String,
        required: true,
        minLength: [10, 'The Description should be a minimum of 10 characters long']
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

 