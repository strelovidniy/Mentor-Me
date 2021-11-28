import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import PropositionType from '../../types/enums/proposition-type.enum';
import CreateMeetingModel from '../../types/create-meeting-model';

@Component({
    selector: 'app-create-meeting-dialog',
    templateUrl: './create-meeting-dialog.component.html',
    styleUrls: ['./create-meeting-dialog.component.css']
})
export default class CreateMeetingDialogComponent implements OnInit {
    public text: string;

    public nameFormControl = new FormControl('', [
        Validators.required
    ]);
    public descriptionFormControl = new FormControl('', [
        Validators.required
    ]);

    public constructor(
        private dialogRef: MatDialogRef<CreateMeetingDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: { type: PropositionType; },
    ) { }

    public ngOnInit(): void {

    }

    public confirm(): void {
        if (this.nameFormControl.valid && this.descriptionFormControl.valid)

            this.dialogRef.close({
                description: this.descriptionFormControl.value,
                emails: [],
                name: this.nameFormControl.value,
                startAt: this.addMins(new Date(Date.now()), 15),
                endAt: this.addMins(new Date(Date.now()), 45)
            } as CreateMeetingModel);
    }

    public discard(): void {
        this.dialogRef.close(undefined);
    }

    public addMins(date: Date, mins: number): Date {
        date.setMinutes(date.getMinutes() + mins);

        return date;
    }
}
