import { AfterViewInit, Component } from '@angular/core';
import PropositionService from '../shared/services/proposition.service';
import TemplateService from '../shared/services/template.service';
import Proposition from '../shared/types/proposition';

@Component({
    selector: 'app-requests',
    templateUrl: './requests.component.html',
    styleUrls: ['./requests.component.css']
})
export default class RequestsComponent implements AfterViewInit {
    public rippleColor = '#3A98DB11';

    public requests: Proposition[];

    public constructor (
        private templateService: TemplateService,
        private propositionService: PropositionService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.requests = await this.propositionService.getRequests();

        this.templateService.TurnLoaderOff();
    }

    public getOwnerName = (request: Proposition): string => request.members.find(u => u.id === request.ownerId).fullName;
}
