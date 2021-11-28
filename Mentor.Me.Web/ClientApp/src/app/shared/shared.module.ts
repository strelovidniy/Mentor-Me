import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { IgxTimePickerComponent } from 'igniteui-angular';
import AddPropositionDialogComponent from './components/add-proposition-dialog/add-proposition-dialog.component';
import ConfirmDialogComponent from './components/confirm-dialog/confirm-dialog.component';
import CreateMeetingDialogComponent from './components/create-meeting-dialog/create-meeting-dialog.component';

import MaterialModule from './material.module';

@NgModule({
    declarations: [
        ConfirmDialogComponent,
        AddPropositionDialogComponent,
        CreateMeetingDialogComponent
    ],
    imports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
    ],
    exports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        IgxTimePickerComponent
    ]
})
export default class SharedModule { }
