import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import User from '../types/user';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class LoginService {
    private user: User;

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) {
        this.getUser();
    }

    public async getUser(): Promise<User> {
        // this.user = await this.http.get<User>(`${this.endpointService.accountUrl}current-user`).toPromise();

        this.user = {
            applyRequests: [],
            bio: '',
            deals: [],
            email: 'roma.dan2001@gmail.com',
            fullName: 'Roman Danylevych',
            id: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
            propositions: [],
            tasks: [],
        };

        return this.user;
    }

    public login(): void {
        location.assign(`${location.origin}/api/v1/account/google-login`);
    }
}
