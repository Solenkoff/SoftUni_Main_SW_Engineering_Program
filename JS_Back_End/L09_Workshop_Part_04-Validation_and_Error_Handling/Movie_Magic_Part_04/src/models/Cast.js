import { Schema, model } from 'mongoose';

const castSchema = new Schema({
    name: {
        type: String,
        required: [true, 'Name is required!'],
        minLength: [5, 'Name should be at least 5 characters long!'],
        match: [/^[a-zA-Z0-9]+$/, 'Name should be alphanumeric, digits and whitespaces only!'],
    },
    age: {
        type: Number,
        min: 1,
        max: 120,
    },
    born: {
        type: String,
        minLength: 10,
        match: /^[a-zA-Z0-9]+$/,
    },
    imageUrl: {
        type: String,
        validate: {         //  deeper validation for  ->   match: /^https?:\/\//
            validator: function(valueToValidate) {
                return /^https?:\/\//.test(valueToValidate);     
            },
            message: (props) => `${props.value} is invalid imageUrl!`
        }
        
    },
});    

const Cast = model('Cast', castSchema);

export default Cast;