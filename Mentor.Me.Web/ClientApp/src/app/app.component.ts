import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export default class AppComponent implements OnInit {
    public title = 'app';

    public ngOnInit(): void {
        AOS.init();
    }
}
