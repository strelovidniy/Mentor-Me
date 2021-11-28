import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import AboutComponent from './about.component';

@NgModule({
    declarations: [
        AboutComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: AboutComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
