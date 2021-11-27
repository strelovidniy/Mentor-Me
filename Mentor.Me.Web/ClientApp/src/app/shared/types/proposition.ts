import PropositionType from './enums/proposition-type.enum';
import Skill from './skill';
import User from './user';

export default class Proposition {
    public id: string;
    public name: string;
    public description: string;
    public type: PropositionType;
    public startPrice: number;
    public active: boolean;
    public ownerId: string;
    public members: User[];
    public skills: Skill[];
}
