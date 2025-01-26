import Cast from "../models/Cast.js";

export default {
    getAll(ids) {
        return Cast.find({});
        // return Cast.find({ _id: { $in: ids } });  -> REturning those casts that are present in the movie(ids)
    },
    create(castData) {
        return Cast.create(castData);
    },
} 