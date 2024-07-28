import { dataService } from '../service/dataService.js';

export async function deleteView(ctx) {
    const id = ctx.params.id;
    const res = confirm('Do you want to delete your furniture?');
    if (res) {
        await dataService.delFurniture(id);
        ctx.goTo('/');
    }

}