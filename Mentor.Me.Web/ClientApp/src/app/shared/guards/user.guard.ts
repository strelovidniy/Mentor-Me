import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import LoginService from '../services/login.service';

@Injectable({
    providedIn: 'root'
})
export default class UserGuard implements CanActivate {
    public constructor (
        private loginService: LoginService,
        private router: Router
    ) { }

    public async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> {
        const user = await this.loginService.getUser();

        if (!user) {
            this.loginService.login();

            return false;
        }

        return true;
    }
}
