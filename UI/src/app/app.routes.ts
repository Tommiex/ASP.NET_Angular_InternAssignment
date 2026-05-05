import { Routes } from '@angular/router';
import { UserList } from './features/user/user-list/user-list';


export const routes: Routes = [
    {
        path: 'admin/user-dashboard',
        component: UserList,
    },

];