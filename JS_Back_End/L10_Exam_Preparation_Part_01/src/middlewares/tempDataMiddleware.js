

export const tempData = ( req, res, next) => {
    res.setError = (message) => {
        res.session.error = {
            message, 
            isFirstRequest: true,
        }
    }

    if(!res.session.error){
        return next();
    }

    if(res.session.isFirstRequest){
        res.session.isFirstRequest = false;
        res.locals.error = res.session.error.message;
    }else{
        res.locals.error = null;
    }

    next();
}