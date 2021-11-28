import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import ConfirmDialogComponent from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import User from 'src/app/shared/types/user';
import * as uuid from 'uuid';

@Component({
    selector: 'app-admin-editor',
    templateUrl: './admin-editor.component.html',
    styleUrls: ['./admin-editor.component.css']
})
export default class AdminEditorComponent implements OnInit {

    public userNameFormControl = new FormControl('', [
        Validators.required
    ]);

    public userEmailFormControl = new FormControl('', [
        Validators.required,
        Validators.email
    ]);

    public userFormGroup = new FormGroup({
        email: this.userEmailFormControl,
        name: this.userNameFormControl,
    });

    public constructor(
        private dialogRef: MatDialogRef<ConfirmDialogComponent>,
        @Inject(MAT_DIALOG_DATA) private data: { edit: boolean; user: User; }
    ) { }

    public ngOnInit(): void {
        if (this.data.edit) {
            this.userNameFormControl.setValue(this.data.user.fullName, { emitEvent: true });
            this.userEmailFormControl.setValue(this.data.user.email, { emitEvent: true });
        }
    }

    public save(): void {
        if (this.userFormGroup.valid) {
            this.dialogRef.close(this.data.edit
                ? {
                    ...this.data.user,
                    fullName: this.userNameFormControl.value,
                    email: this.userEmailFormControl.value
                } as User
                : {
                    applyRequests: [],
                    bio: '',
                    deals: [],
                    fullName: this.userNameFormControl.value,
                    id: uuid.NIL,
                    propositions: [],
                    tasks: [],
                    isAdmin: false,
                    email: this.userEmailFormControl.value
                } as User);
        }
    }

    public discard(): void {
        this.dialogRef.close(undefined);
    }
}
