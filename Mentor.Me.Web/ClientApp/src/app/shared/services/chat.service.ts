import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Chat from '../types/Chat';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class ChatService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getUnreadChats(userId: string): Promise<Chat[]> {
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}unread/${userId}`).toPromise();
    }

    public getReadChats(userId: string): Promise<Chat[]> {
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}read/${userId}`).toPromise();
    }

    public getChatById(chatId: string): Promise<Chat> {
        return this.http.get<Chat>(`${this.endpointService.chatUrl}${chatId}`).toPromise();
    }
}
