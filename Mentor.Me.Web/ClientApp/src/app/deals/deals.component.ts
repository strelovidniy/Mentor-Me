import { AfterViewInit, Component } from '@angular/core';
import { Router } from '@angular/router';
import DealService from '../shared/services/deal.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import Deal from '../shared/types/deal';
import User from '../shared/types/user';

@Component({
    selector: 'app-deals',
    templateUrl: './deals.component.html',
    styleUrls: ['./deals.component.css']
})
export default class DealsComponent implements AfterViewInit {
    public rippleColor = '#3A98DB11';

    public deals: Deal[];

    private user: User;

    public constructor(
        private templateService: TemplateService,
        private loginService: LoginService,
        private dealService: DealService,
        private router: Router
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.user = await this.loginService.getUser();

        this.deals = await this.dealService.getUserDeals(this.user.id);

        this.templateService.TurnLoaderOff();
    }

    public openChat(deal: Deal, event: any): void {
        event.stopPropagation();

        this.router.navigate(['/chat', deal.chat.id]);
    }

    public getOwnerName = (deal: Deal): string => deal?.members?.find(u => u?.id == deal?.ownerId)?.fullName;
}
