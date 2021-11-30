import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Chat from '../types/chat';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class ChatService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getChatById(chatId: string): Promise<Chat> {
        return this.http.get<Chat>(`${this.endpointService.chatUrl}${chatId}`).toPromise();
    }
}
