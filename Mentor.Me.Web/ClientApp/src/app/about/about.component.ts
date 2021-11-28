import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-about',
    templateUrl: './about.component.html',
    styleUrls: ['./about.component.css']
})
export default class AboutComponent implements AfterViewInit {

    public constructor(
        private templateService: TemplateService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.templateService.TurnLoaderOff();
    }
}
