import { NgModule } from '@angular/core';

import LoaderComponent from './loader/loader.component';
import TemplateComponent from './template.component';
import SharedModule from '../shared/shared.module';

@NgModule({
    declarations: [
        LoaderComponent,
        TemplateComponent
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        TemplateComponent
    ]
})
export default class TemplateModule { }
