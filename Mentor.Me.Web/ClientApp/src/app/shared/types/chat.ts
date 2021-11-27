import Message from './message';
import User from './user';

export default class Chat {
    public id: string;
    public participants: User[];
    public name: string;
    public dealId: string;
    public hasUnreadMessages: boolean;
    public messages: Message[];
}
