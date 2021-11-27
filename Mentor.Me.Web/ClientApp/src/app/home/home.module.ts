import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import HomeComponent from './home.component';
import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: HomeComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
