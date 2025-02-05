export const tempData = (req, res, next) => {
    //  Attach error setter to res
    res.setError = (message) => {
        req.session.error = {
            message,
            isfirstRequest: true,
        }
    }

    if(!req.session.error){
        return next();
    }

    if(req.session.error.isfirstRequest){
        req.session.error.isfirstRequest = false;
        res.locals.error = req.session.error.message;
    }else{
        req.session.error = null;
    }

    next();
}; 