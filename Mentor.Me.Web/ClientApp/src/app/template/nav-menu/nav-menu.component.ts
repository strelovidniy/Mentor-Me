import { Component } from '@angular/core';
import INavPage from 'src/app/shared/types/interfaces/nav-page.interface';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export default class NavMenuComponent {
    public pages: INavPage[] = [
        {
            name: 'Home',
            routerLink: '/'
        },
        {
            name: 'Chat',
            routerLink: '/chat'
        },
        {
            name: 'Admin',
            routerLink: '/admin'
        }];
}