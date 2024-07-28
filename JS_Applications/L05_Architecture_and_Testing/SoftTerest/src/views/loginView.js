import { html } from '../app.js';
import { userService } from '../service/userService.js';
import { createSubmitHandler, userHelper } from '../utility/userHelper.js';

const loginTemplate = () => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Login User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${createSubmitHandler(onLogin)}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <input type="submit" class="btn btn-primary" value="Login" />
        </div>
    </div>
</form>
`;

let context = null;
export function showLoginView (ctx) {
    context = ctx;
    context.render(loginTemplate());

}

async function onLogin({email, password}) {
    if (!email || !password) {
        return  alert('Error in login');
    }

    const userData = await userService.login({email, password});
    userHelper.setUserData(userData);
    context.updateNav();
    context.goTo('/');
}
