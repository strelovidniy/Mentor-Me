import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import AppComponent from './app.component';
import TemplateModule from './template/template.module';
import AdminGuard from './shared/guards/admin.guard';
import AnimGuard from './shared/guards/anim.guard';
import UserGuard from './shared/guards/user.guard';
import RequestsInteceptor from './shared/interceptors/requests.interceptor';
import LoginService from './shared/services/login.service';

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
            { path: 'about', loadChildren: (): any => import('./about/about.module').then(m => m.default), pathMatch: 'full' },
            { path: 'deals', loadChildren: (): any => import('./deals/deals.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'requests', loadChildren: (): any => import('./requests/requests.module').then(m => m.default), pathMatch: 'prefix' },
            { path: '**', redirectTo: '/error/not-found' },
        ])
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: RequestsInteceptor, multi: true },
        LoginService,
        AnimGuard,
        UserGuard,
        AdminGuard,
    ],
    bootstrap: [AppComponent]
})
export default class AppModule { }
