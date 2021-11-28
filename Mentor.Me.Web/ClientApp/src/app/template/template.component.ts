import { Component } from '@angular/core';

@Component({
    selector: 'app-template',
    templateUrl: './template.component.html',
    styleUrls: ['./template.component.css']
})
export default class TemplateComponent {
    public menuOpened: boolean;

    public onLoaded(): void {
        document.getElementById('loader').style.display = 'none';
    }

    public onLoadingStarted(): void {
        document.getElementById('loader').style.opacity = 'block';
    }

    public async mobileMenuClicked(): Promise<void> {
        if (this.menuOpened == true){
            document.getElementById('dropdown-content').classList.remove('opening');
            document.getElementById('dropdown-content').classList.add('closing');
        } else {
            document.getElementById('dropdown-content').classList.remove('closing');
            document.getElementById('dropdown-content').classList.add('opening');
        }
        await new Promise(resolve => setTimeout(resolve, 300));
        this.menuOpened = !this.menuOpened;
    }
}
