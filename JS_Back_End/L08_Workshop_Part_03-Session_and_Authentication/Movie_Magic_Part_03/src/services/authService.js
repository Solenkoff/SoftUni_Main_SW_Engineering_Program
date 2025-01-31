import User from "../models/user.js";

export default {
    register(userData){
        return User.create(userData);
    }
} 