import validator from 'validator';
import isEmail from 'validator/lib/isEmail.js';   //  partial library import
//import { isEmail } from 'validator';              //  complete library import

console.log(validator.isBoolean('false'));
console.log(validator.isEmail('sol@abv.bg'));
console.log(validator.isStrongPassword('asdasd'));