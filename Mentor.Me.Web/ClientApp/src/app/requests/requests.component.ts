import { AfterViewInit, Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import AddPropositionDialogComponent from '../shared/components/add-proposition-dialog/add-proposition-dialog.component';
import LoginService from '../shared/services/login.service';
import PropositionService from '../shared/services/proposition.service';
import TemplateService from '../shared/services/template.service';
import PropositionType from '../shared/types/enums/proposition-type.enum';
import Proposition from '../shared/types/proposition';
import User from '../shared/types/user';

@Component({
    selector: 'app-requests',
    templateUrl: './requests.component.html',
    styleUrls: ['./requests.component.css']
})
export default class RequestsComponent implements AfterViewInit {
    public rippleColor = '#3A98DB11';

    public requests: Proposition[];

    public filterFormControl = new FormControl();

    public valueChangesSubscription: Subscription;

    private user: User;

    public constructor (
        private templateService: TemplateService,
        private propositionService: PropositionService,
        private loginService: LoginService,
        private dialog: MatDialog
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        await this.getRequests();

        this.user = await this.loginService.getUser();

        this.templateService.TurnLoaderOff();
    }

    public getOwnerName = (request: Proposition): string => request.members.find(u => u.id === request.ownerId).fullName;

    public async getRequests(filter?: string): Promise<void> {
        this.requests = await this.propositionService.getRequests(filter);
    }

    public async add(event: any): Promise<void> {
        event.stopPropagation();

        this.propositionService.creteProposition({ ...await this.dialog.open(AddPropositionDialogComponent, {
            data: {
                type: PropositionType.Request
            },
            width: '400px'
        }).afterClosed().toPromise(),
        ownerId: this.user.id,
        members: [this.user]
        });
    }
}
