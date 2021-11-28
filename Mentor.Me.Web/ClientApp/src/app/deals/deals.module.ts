import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import DealsComponent from './deals.component';

@NgModule({
    declarations: [
        DealsComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: DealsComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class DealsModule { }
