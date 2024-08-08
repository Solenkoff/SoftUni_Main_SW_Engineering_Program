import { dataService } from "../services/dataService.js";


export async function deleteItem(ctx){
    const id = ctx.params.id;

    const response = confirm('delete');
    if(response){
        await dataService.deleteFurniture(id);
        ctx.goTo('/');
    }
   
}
