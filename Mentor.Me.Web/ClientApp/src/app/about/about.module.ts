import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IvyCarouselModule } from 'angular-responsive-carousel';
import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import AboutComponent from './about.component';

@NgModule({
    declarations: [
        AboutComponent
    ],
    imports: [
        IvyCarouselModule,
        SharedModule,
        RouterModule.forChild([
            { path: '', component: AboutComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
