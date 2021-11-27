import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export default class EndpointService {
    public readonly chatUrl = 'https://localhost:7024/api/v1/chats/';
    public readonly adminUrl = 'https://localhost:7024/api/v1/admin/';
    public readonly accountUrl = 'https://localhost:7024/api/v1/account/';
    public readonly goalsUrl = 'https://localhost:7024/api/v1/goals/';
}
