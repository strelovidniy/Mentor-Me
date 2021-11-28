import { AfterViewInit, Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import CreateMeetingDialogComponent from '../shared/components/create-meeting-dialog/create-meeting-dialog.component';
import DealService from '../shared/services/deal.service';
import GoogleCalendarService from '../shared/services/google-calendar.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import CreateMeetingModel from '../shared/types/create-meeting-model';
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
        private router: Router,
        private dialog: MatDialog,
        private googleCalendarService: GoogleCalendarService
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

    public async scheduleMeeting(deal: Deal): Promise<void> {
        const res: CreateMeetingModel = await this.dialog.open(CreateMeetingDialogComponent).afterClosed().toPromise();

        console.dir(res);

        if (res) {
            res.emails = deal.members.map(u => u.email);

            await this.googleCalendarService.scheduleMeeting(res);
        }
    }
}
