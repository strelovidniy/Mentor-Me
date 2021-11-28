import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-requests',
    templateUrl: './requests.component.html',
    styleUrls: ['./requests.component.css']
})
export default class RequestsComponent implements AfterViewInit {
    public rippleColor = '#3A98DB11';

    public constructor (
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
