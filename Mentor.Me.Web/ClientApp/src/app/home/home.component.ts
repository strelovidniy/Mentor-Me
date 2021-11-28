import { AfterViewInit, Component } from '@angular/core';
import PropositionService from '../shared/services/proposition.service';
import TemplateService from '../shared/services/template.service';
import Proposition from '../shared/types/proposition';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export default class HomeComponent implements AfterViewInit {
    public rippleColor = '#3A98DB11';

    public offers: Proposition[];

    public constructor (
        private templateService: TemplateService,
        private propositionService: PropositionService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.offers = await this.propositionService.getOffers();

        this.templateService.TurnLoaderOff();
    }

    public getOwnerName = (offer: Proposition): string => offer.members.find(u => u.id === offer.ownerId).fullName;
}
