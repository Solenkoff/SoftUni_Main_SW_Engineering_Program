import { Schema, model, Types } from 'mongoose';

//  Create schema
const movieSchema = new Schema({
    title: {
        type: String,
        required: [true, 'Title is required!'],
        minLength: [5, 'Title should be at least 5 characters long!'],
        maxLength: 250,
        match: [/^[a-zA-Z 0-9]+$/, 'Title should be alphanumeric, digits and whitespaces only!'],
    },
    category: {
        type: String,
        required: true,
        enum: {
            values: [
                'tv - show',
                'animation',
                'movie',
                'documentary',
                'short - film',
            ],
            message: '{VALUE} is not supported'
        },
    },
    genre: {
        type: String,
        required: [true, 'Genre is required!'],
        minLength: [5, 'Genre should be at least 5 characters long!'],
        maxLength: 250,
        match: [/^[a-zA-Z 0-9]+$/, 'Genre should be alphanumeric, digits and whitespaces only!'],
    },
    director: {
        type: String,
        minLength: [5, 'Director should be at least 5 characters long!'],
        maxLength: 250,
        match: [/^[a-zA-Z 0-9]+$/, 'Director should be alphanumeric, digits and whitespaces only!'],
    },
    year: {
        type: Number,
        min: 1900,
        max: 2025,
    },
    imageUrl: {
        type: String,
        match: /^https?:\/\//,
    },
    rating: {
        type: Number,
        min: 1,
        max: 5,
    },
    description: {
        type: String,
        minLength: 20,
        match: /^[a-zA-Z 0-9]+$/,
    },
    // casts: {
    //     type: Types.ObjectId,  
    //     ref: 'Cast' 
    // } 

    casts: [{
        _id: false,
        character: String,
        cast: {
            type: Types.ObjectId,
            ref: 'Cast'
        }
    }],
    creator: {
        type: Types.ObjectId,
        ref: 'User',
    }
});

//  Create model
const Movie = model('Movie', movieSchema);


//  Export model
export default Movie;