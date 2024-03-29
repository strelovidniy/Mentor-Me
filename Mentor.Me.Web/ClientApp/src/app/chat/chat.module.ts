import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import ChatComponent from './chat.component';

@NgModule({
    declarations: [
        ChatComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: ':chatId', component: ChatComponent, pathMatch: 'preffix', /* canActivate: [UserGuard], */ canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
