import { login } from '../data/users.js';
import { html, page, render } from '../lib.js';
import { createSubmitHandler, updateNav } from '../util.js';


const loginTemplate = ( onLogin ) => html`
    <section id="login-page" class="auth">
        <form id="login" @submit=${onLogin}>
            <div class="container">
                <div class="brand-logo"></div>
                <h1>Login</h1>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">
                <label for="login-pass">Password:</label>
                <input type="password" id="login-password" name="password">
                <input type="submit" class="btn submit" value="Login">
                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </div>
        </form>
    </section>
`;


export function showLogin(ctx){
    render(loginTemplate(createSubmitHandler(onLogin)));
}

async function onLogin({email, password}, form){
    if(!email || !password){
        return alert('All fields are required!');
    }

    await login(email,password);
    updateNav();
    page.redirect('/');
}