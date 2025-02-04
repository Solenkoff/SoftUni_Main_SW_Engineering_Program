import { Schema, model } from "mongoose";
import bcrypt from 'bcrypt';

const userSchema = new Schema({
    email: {
        type: String,
        unique: true,
        minLength: 10,
        match: /\@[a-zA-Z0-9]+.[a-zA-Z0-9]+$/,
    },
    password:  {
        type: String,
        minLength: 6,
        match: /^\w+$/,
    },
});

userSchema.virtual('rePassword')
    .set(function(rePassword) {
        if(rePassword !== this.password){
            throw new Error('Password missmatch!');
        }
    })
  //.get()    getter if we need the rePassword somewhere...

userSchema.pre('save', async function(){
    this.password = await bcrypt.hash(this.password, 10);  
});

const User = model('User', userSchema);

export default User;