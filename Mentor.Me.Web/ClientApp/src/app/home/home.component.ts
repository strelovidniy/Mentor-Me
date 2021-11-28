import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import AddPropositionDialogComponent from '../shared/components/add-proposition-dialog/add-proposition-dialog.component';
import LoginService from '../shared/services/login.service';
import PropositionService from '../shared/services/proposition.service';
import TemplateService from '../shared/services/template.service';
import PropositionType from '../shared/types/enums/proposition-type.enum';
import Proposition from '../shared/types/proposition';
import User from '../shared/types/user';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export default class HomeComponent implements OnInit, AfterViewInit {
    public rippleColor = '#3A98DB11';

    public offers: Proposition[];

    public filterFormControl = new FormControl();

    public valueChangesSubscription: Subscription;

    private user: User;

    public constructor (
        private templateService: TemplateService,
        private propositionService: PropositionService,
        private loginService: LoginService,
        private dialog: MatDialog
    ) { }

    public ngOnInit(): void {
        this.valueChangesSubscription = this.filterFormControl.valueChanges.pipe(debounceTime(400)).subscribe(async value => this.getOffers(value));
    }

    public async ngAfterViewInit(): Promise<void> {
        await this.getOffers();

        this.user = await this.loginService.getUser();

        this.templateService.TurnLoaderOff();
    }

    public getOwnerName = (offer: Proposition): string => offer.members.find(u => u.id === offer.ownerId).fullName;

    public async getOffers(filter?: string): Promise<void> {
        this.offers = await this.propositionService.getOffers(filter);
    }

    public async addOffer(event: any): Promise<void> {
        event.stopPropagation();

        const res = await this.dialog.open(AddPropositionDialogComponent, {
            data: {
                type: PropositionType.Offer
            },
            width: '400px'
        }).afterClosed().toPromise();

        if (res) {

            this.propositionService.creteProposition({ ...res,
                ownerId: this.user.id,
                members: [this.user]
            });

            await this.getOffers();
        }
    }
}
