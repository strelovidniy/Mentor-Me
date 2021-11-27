import { NgModule } from '@angular/core';

import LoaderComponent from './loader/loader.component';
import TemplateComponent from './template.component';
import NavMenuComponent from './nav-menu/nav-menu.component';
import SharedModule from '../shared/shared.module';

@NgModule({
    declarations: [
        LoaderComponent,
        TemplateComponent,
        NavMenuComponent
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        TemplateComponent
    ]
})
export default class TemplateModule { }
