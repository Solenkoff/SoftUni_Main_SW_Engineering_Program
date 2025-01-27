import Cast from "../models/Cast.js";

export default {
    getAll(filter = {}) {
        let query = Cast.find({});
        // return Cast.find({ _id: { $in: ids } });  -> REturning those casts that are present in the movie(ids)

        if(filter.exclude){
            //query = query.find({_id: {$nin: filter.exclude}});   //  with mongodb
            query = query.nin('id', filter.exclude);              //  with mongoose
        }

        return query;
    },
    create(castData) {
        return Cast.create(castData);
    },
} 