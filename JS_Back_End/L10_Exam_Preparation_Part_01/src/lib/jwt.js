import util from 'util';
import jwtOriginal from 'jsonwebtoken';

const verify = util.promisify(jwtOriginal.verify);    
const sign = util.promisify(jwtOriginal.sign);
const decode = util.promisify(jwtOriginal.decode);

const jwt = {
    verify,
    sign,
    decode,
};

export default jwt;