import { AfterViewInit, Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import ChatService from '../shared/services/chat.service';
import EndpointService from '../shared/services/endpoint.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import Chat from '../shared/types/Chat';
import Message from '../shared/types/message';
import User from '../shared/types/user';
import * as uuid from 'uuid';

@Component({
    selector: 'app-chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.css']
})
export default class ChatComponent implements AfterViewInit {

    public chat: Chat;

    public messageInputFormControl = new FormControl();

    private chatId: string;
    private connection: signalR.HubConnection;
    private user: User;

    public constructor(
        private templateService: TemplateService,
        private endpointService: EndpointService,
        private chatService: ChatService,
        private route: ActivatedRoute,
        private loginService: LoginService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.user = await this.loginService.getUser();

        this.chatId = this.route.snapshot.paramMap.get('chatId');

        this.chat = await this.chatService.getChatById(this.chatId);

        console.log(this.chat);

        this.connection = new signalR.HubConnectionBuilder()
                .configureLogging(signalR.LogLevel.Information)
                .withUrl(`${this.endpointService.chatUrl}messages-hub`)
                .withAutomaticReconnect()
                .build();

        await this.connection.start();

        await this.invokeSignalR();

        this.connection.onreconnected(() => this.invokeSignalR());

        this.connection.on('RecieveMessage', (receivedMessage: any) => {
            this.chat?.messages?.push(receivedMessage);
        });

        this.templateService.TurnLoaderOff();
    }

    public async ngOnDestroy(): Promise<void> {
        await this.connection?.invoke('LeaveTheGroup', this.chatId);
        await this.connection.stop();
    }

    public sendMessage(): void {
        if (this.messageInputFormControl.value) {
            const message = this.messageInputFormControl?.value?.trim();

            this.messageInputFormControl.reset();

            if (message) {
                this.connection.invoke('SendMessageToGroup', {
                    chatId: this.chat.id,
                    date: new Date(Date.now()),
                    id: uuid.NIL,
                    sender: this.user,
                    senderId: this.user.id,
                    text: message
                } as Message);
            }

            this.chat.messages.push();
        } else {

        }
    }

    private async invokeSignalR(): Promise<void> {
        await this.connection.invoke('EnterToGroup', this.chatId);
    }
}
