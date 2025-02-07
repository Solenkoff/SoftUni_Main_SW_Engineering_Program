import { Schema, model } from "mongoose";

//  TODO: Modify user schema
const userSchema = new Schema({
    email: {
        type: String,
        required: true,
    },
    username: {
        type: String,
        required: true,
    },
    password: {
        type: String,
        required: true,
    },
});


const User = model('User', userSchema);

export default User;