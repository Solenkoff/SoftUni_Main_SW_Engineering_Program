import { Schema, model } from "mongoose";
import bcrypt from 'bcrypt';

const userSchema = new Schema({
    username: {
        type: String,
        required: [true, 'Username is required!'],
        minLength: [2, 'The username should be at least 2 characters long'],
    },
    email: {
        type: String,
        required: [true, 'Email is required!'],
        minLength: [10, 'The email should be at least 10 characters long'],
    },
    password: {
        type: String,
        required: [true, 'Password is required!'],
        minLength: [4, 'The password should be at least 4 characters long']
    },
});

userSchema.pre('save', async function () {
    this.password = await bcrypt.hash(this.password, 10);
});

const User = model('User', userSchema);

export default User;