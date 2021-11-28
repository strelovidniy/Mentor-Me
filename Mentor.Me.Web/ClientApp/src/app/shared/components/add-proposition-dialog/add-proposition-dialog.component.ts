import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import Proposition from '../../types/proposition';
import * as uuid from 'uuid';
import PropositionType from '../../types/enums/proposition-type.enum';
import Skill from '../../types/skill';

@Component({
    selector: 'app-add-proposition-dialog',
    templateUrl: './add-proposition-dialog.component.html',
    styleUrls: ['./add-proposition-dialog.component.css']
})
export default class AddPropositionDialogComponent implements OnInit {
    public text: string;

    public nameFormControl = new FormControl('', [
        Validators.required
    ]);
    public descriptionFormControl = new FormControl('', [
        Validators.required
    ]);
    public priceFormControl = new FormControl('', [
        Validators.required
    ]);

    public skillFormControls: FormControl[] = [];

    public constructor(
        private dialogRef: MatDialogRef<AddPropositionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: { type: PropositionType; },
    ) { }

    public ngOnInit(): void {

    }

    public confirm(): void {
        if (!this.skillFormControls.map(s => s.valid).includes(false) && this.priceFormControl.valid && this.nameFormControl.valid && this.descriptionFormControl.valid)

            this.dialogRef.close({
                active: true,
                description: this.descriptionFormControl.value,
                id: uuid.NIL,
                members: [],
                name: this.nameFormControl.value,
                ownerId: '',
                skills: this.skillFormControls.map(skill => {
                    return {
                        name: skill.value,
                        id: uuid.NIL,
                        propositionId: uuid.NIL,
                        tasks: []
                    } as Skill;
                }),
                startPrice: this.priceFormControl.value,
                type: this.data.type
            } as Proposition);
    }

    public discard(): void {
        this.dialogRef.close(undefined);
    }

    public addSkill(): void {
        this.skillFormControls.push(new FormControl('', [
            Validators.required
        ]));
    }
}
