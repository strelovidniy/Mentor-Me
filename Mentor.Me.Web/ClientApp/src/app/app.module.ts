import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import AppComponent from './app.component';
import TemplateModule from './template/template.module';

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        TemplateModule,
        HttpClientModule,
        BrowserAnimationsModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        RouterModule.forRoot([
            { path: '', redirectTo: '/home', pathMatch: 'full' },
            { path: 'home', loadChildren: (): any => import('./home/home.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'admin', loadChildren: (): any => import('./admin/admin.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'error', loadChildren: (): any => import('./error/error.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'chat', loadChildren: (): any => import('./chat/chat.module').then(m => m.default), pathMatch: 'prefix' },
            { path: '**', redirectTo: '/error/not-found' },
        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export default class AppModule { }
