import User from './user';

export default class Message {
    public id: string;
    public text: string;
    public chatId: string;
    public senderId: string;
    public sender: User;
    public date: Date;
}
