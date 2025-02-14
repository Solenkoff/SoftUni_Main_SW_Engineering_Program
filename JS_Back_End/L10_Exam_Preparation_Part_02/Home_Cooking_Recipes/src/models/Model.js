import { Schema, model, Types } from 'mongoose';

const modelSchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: [2, 'The Name should be at least 2 characters']
    },
    typeModel: {
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
    image: {
        type: String,
        required: true,
        validate: [ /^https?:\/\//, 'The Disaster Image should start with http:// or https://' ]
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

const Model = model('Model', modelSchema);

export default Model;

 