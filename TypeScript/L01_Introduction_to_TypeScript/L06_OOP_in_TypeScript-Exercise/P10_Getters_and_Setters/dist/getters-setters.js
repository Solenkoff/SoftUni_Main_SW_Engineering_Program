"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class User {
    _username;
    constructor(username) {
        this.username = username;
    }
    get username() {
        return this._username;
    }
    set username(newUsername) {
        if (newUsername.length < 3) {
            throw new Error('Username must be at least 3 characters long!');
        }
        this._username = newUsername;
    }
}
const user = new User("Martin");
user.username = "brrrrr";
console.log(user.username);
// const user = new User("jo");           //   Error
// const user = new User("Martin");       //   Error
// user.username = "Do";
//# sourceMappingURL=getters-setters.js.map