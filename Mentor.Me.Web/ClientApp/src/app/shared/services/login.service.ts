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

        // if (!this.user) this.login();

        // return this.user;

        return {
            id: 'df17b583-bf87-4163-a835-b0289df0ed95',
            email: 'boredarthur@gmail.com',
            fullName: 'Arthur Zavolovych',
            bio: 'bio',
            tasks: [],
            propositions: [],
            applyRequests: [],
            deals: [],
            isAdmin: true
        };
    }

    public login(): void {
        location.assign(`${this.endpointService.accountUrl}authenticate`);
    }
}
