import { Schema, model, Types } from 'mongoose';

const disasterSchema = new Schema({
    name: {
        type: String,
        required: [true, 'Name is required'],
        minLength: [2, 'The Name should be at least 2 characters long']
    },
    typeDisaster: {
        type: String,
        required: [true, 'Type is required'],
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
        required: [true, 'Eventyear is required'],
        min: [0, 'The Year should be between 0 and 2024'],
        max: [2024, 'The Year should be between 0 and 2024']
    },
    location: {
        type: String,
        required: [true, 'Location is required'],
        minLength: [3, 'The Location should be at least 3 characters long']
    },
    image: {
        type: String,
        required: [true, 'Image is required'],
        validate: [ /^https?:\/\//, 'The image link should start with http:// or https://' ]
    },
    description: {
        type: String,
        required: [true, 'Description is required'],
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

 