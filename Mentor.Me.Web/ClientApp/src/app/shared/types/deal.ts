import Chat from './chat';
import User from './user';

export default class Deal {
    public id: string;
    public ownerId: string;
    public propositionId: string;
    public members: User[];
    public chat: Chat;
}
