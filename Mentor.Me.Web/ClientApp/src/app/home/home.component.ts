import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export default class HomeComponent implements AfterViewInit {

    public constructor (
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
