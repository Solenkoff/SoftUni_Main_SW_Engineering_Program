export const tempData = ( req, res, next) => {
    res.setError = (message) => {
        req.session.error = {
            message, 
            isFirstRequest: true,
        };
    };

    if(!req.session.error){
        return next();
    }

    if(req.session.error.isFirstRequest){
        req.session.error.isFirstRequest = false;
        console.log(req.session.error.message);
        res.locals.error = req.session.error.message;
    }else{
        req.session.error = null;
    }

    next();
}