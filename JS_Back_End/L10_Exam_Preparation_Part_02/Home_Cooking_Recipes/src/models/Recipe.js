import { Schema, model, Types } from 'mongoose';

const modelSchema = new Schema({
    title: {
        type: String,
        required: true,
        minLength: [2, 'The Title should be at least 2 characters long']
    },
    ingredients: {
        type: String,
        required: true,
        minLength: [10, 'At least 10 characters are required'],
        maxLength: [200, 'Can not exceed the maximum of 200 chatacters for this section'],
    },
    instructions: {
        type: String,
        required: true,
        minLength: [10, 'At least 10 characters are required'],
    },
    description : {
        type: String,
        required: true,
        minLength: [10, 'At least 10 characters are required'],
        maxLength: [100, 'Can not exceed the maximum of 100 chatacters for this section'],
    },
    image: {
        type: String,
        required: true,
        validate: [ /^https?:\/\//, 'The Disaster Image should start with http:// or https://' ]
    },
    recommendList : [{
        type: Types.ObjectId,
        ref: 'User'
    }],
    owner: {
        type: Types.ObjectId,
        ref: 'User'
    }
},{
    timestamps: true,
});

const Recipe = model('Recipe', modelSchema);

export default Recipe;

 