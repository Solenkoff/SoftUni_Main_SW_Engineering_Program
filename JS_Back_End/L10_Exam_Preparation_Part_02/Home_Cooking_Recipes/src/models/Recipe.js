import { Schema, model, Types } from 'mongoose';

const modelSchema = new Schema({
    title: {
        type: String,
        required: true,
        //minLength: [2, 'The Name should be at least 2 characters']
    },
    ingredients: {
        type: String,
        required: true,
    },
    instructions: {
        type: String,
        required: true,
    },
    description : {
        type: String,
        required: true,
    },
    image: {
        type: String,
        required: true,
        // validate: [ /^https?:\/\//, 'The Disaster Image should start with http:// or https://' ]
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

 