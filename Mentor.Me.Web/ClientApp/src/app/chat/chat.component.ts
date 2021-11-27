import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import ChatService from '../shared/services/chat.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import Chat from '../shared/types/Chat';

@Component({
    selector: 'app-chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.css']
})
export default class ChatComponent implements OnInit, AfterViewInit {

    public chats: Chat[] = [
        {
            dealId: '0000-0000-000000-000-000000',
            hasUnreadMessages: true,
            id: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
            messages: [],
            name: 'Chat 1',
            participants: [],
        },

        {
            dealId: '0000-0000-000000-000-000000',
            hasUnreadMessages: true,
            id: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
            messages: [],
            name: 'Chat 1',
            participants: []
        }
    ];

    public constructor(
        private templateService: TemplateService,
        private chatService: ChatService,
        private router: Router,
        private loginService: LoginService
    ) { }

    public ngOnInit(): void {

    }

    public async ngAfterViewInit(): Promise<void> {
        this.chats.push(...((await this.chatService.getUnreadChats((await this.loginService.getUser()).id)) || []));
        this.chats.push(...((await this.chatService.getReadChats((await this.loginService.getUser()).id)) || []));
        this.templateService.TurnLoaderOff();
    }

    public onChatCardClick(chat: Chat): void {
        this.router.navigate([`/chat/${chat.id}`]);
    }
}
