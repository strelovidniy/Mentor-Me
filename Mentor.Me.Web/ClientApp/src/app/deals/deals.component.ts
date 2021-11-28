import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-deals',
    templateUrl: './deals.component.html',
    styleUrls: ['./deals.component.css']
})
export default class DealsComponent implements AfterViewInit {

    public constructor(
        private templateService: TemplateService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.templateService.TurnLoaderOff();
    }
}
