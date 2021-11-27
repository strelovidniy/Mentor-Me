import AssignmentStatus from './enums/task-status.enum';
import User from './user';

export default class Assignment {
    public id: string;
    public name: string;
    public description: string;
    public deadLine: Date;
    public ownerId: string;
    public skillId: string;
    public status: AssignmentStatus;
    public members: User[];
}
