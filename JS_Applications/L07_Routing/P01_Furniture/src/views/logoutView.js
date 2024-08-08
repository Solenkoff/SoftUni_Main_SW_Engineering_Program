import { userService } from "../services/userService.js";
import { userHelper } from "../utilities/userHelper.js";

export async function showLogoutView(ctx){
    await userService.logout();
    userHelper.clearUserData();
    ctx.updateNav();
    ctx.goTo('/');
    
}
