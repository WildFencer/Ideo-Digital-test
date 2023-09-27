import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'update-invoice-dialog',
  templateUrl: './update-invoice-dialog.template.html',
  styleUrls: ['./update-invoice-dialog.component.scss']
})
export class UpdateInvoiceDialogComponent {

@Input() title: string = 'Create Invoice';
formGroup: FormGroup;
post: any = '';

constructor(private formBuilder: FormBuilder) { }

    createForm() {
        this.formGroup = this.formBuilder.group({
            'id': [null],
            'description': [null, Validators.required],
            'amount': [null, Validators.required],
            'customerId': [null, Validators.required],
            'billingStatusId': [null],
        });
    }

    onSubmit(formData: any) {
        this.post = formData;
    }
    
}
