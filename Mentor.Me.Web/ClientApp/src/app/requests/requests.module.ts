import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import RequestsComponent from './requests.component';
import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';

@NgModule({
    declarations: [
        RequestsComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: RequestsComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class RequestsModule { }
