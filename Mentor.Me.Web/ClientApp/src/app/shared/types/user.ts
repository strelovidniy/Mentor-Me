import ApplyRequest from './apply-request';
import Assignment from './assignment';
import Deal from './deal';
import Proposition from './proposition';

export default class User {
    public id: string;
    public fullName: string;
    public bio: string;
    public email: string;
    public propositions: Proposition[];
    public applyRequests: ApplyRequest[];
    public deals: Deal[];
    public tasks: Assignment[];
    public isAdmin: boolean;
}
