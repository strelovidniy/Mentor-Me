import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import TemplateService from '../../shared/services/template.service';
import * as signalR from '@microsoft/signalr';
import EndpointService from 'src/app/shared/services/endpoint.service';
import { ActivatedRoute } from '@angular/router';
import Chat from 'src/app/shared/types/Chat';
import ChatService from 'src/app/shared/services/chat.service';
import Message from 'src/app/shared/types/message';

@Component({
    selector: 'app-messenger',
    templateUrl: './messenger.component.html',
    styleUrls: ['./messenger.component.css']
})
export default class MessengerComponent implements AfterViewInit, OnDestroy {
    public chat: Chat = {
        dealId: '0000-0000-000000-000-000000',
        hasUnreadMessages: true,
        id: '0000-0000-000000-000-000000',
        messages: [],
        name: 'Chat 1',
        participants: []
    };

    public messageInputFormControl = new FormControl();

    private chatId: string;

    private connection: signalR.HubConnection;

    public constructor(
        private templateService: TemplateService,
        private endpointService: EndpointService,
        private chatService: ChatService,
        private route: ActivatedRoute,
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.chatId = this.route.snapshot.paramMap.get('chatId');

        const chat = await this.chatService.getChatById(this.chatId);

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
                    chatId: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
                    date: new Date(Date.now()),
                    id: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
                    sender: null,
                    senderId: 'f3d63443-e92c-4b75-b80b-d67051285dc9',
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
