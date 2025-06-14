import { Schema, model } from "mongoose";
import bcrypt from 'bcrypt';

const userSchema = new Schema({
    email: {
        type: String,
        required: true,
        unique: true,
        lowercase: true,
        minLength: 10,
        match: /\@[a-zA-Z0-9]+.[a-zA-Z0-9]+$/,
    },
    password: {
        type: String,
        minLength: [6, 'Password should be at least 6 charactars long!'],
        match: /^\w+$/,
        trim: true,
    },
});

userSchema.virtual('rePassword')
    .set(function (rePassword) {
        if (rePassword !== this.password) {
            throw new Error('Password missmatch!');
        }
    })
//.get()    getter if we need the rePassword somewhere...

userSchema.pre('save', async function () {
    this.password = await bcrypt.hash(this.password, 10);
});

const User = model('User', userSchema);

export default User;