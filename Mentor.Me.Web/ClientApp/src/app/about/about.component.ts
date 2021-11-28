import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-about',
    templateUrl: './about.component.html',
    styleUrls: ['./about.component.css']
})

export default class AboutComponent implements AfterViewInit {
    public isStudent = true;
    public isShowingSteps = false;

    public constructor(
        private templateService: TemplateService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.templateService.TurnLoaderOff();
    }

    public typeChoosed(): void {
        this.isStudent = !this.isStudent;
    }

    public toggleSteps(): void {
        this.isShowingSteps = true;
    }
}
