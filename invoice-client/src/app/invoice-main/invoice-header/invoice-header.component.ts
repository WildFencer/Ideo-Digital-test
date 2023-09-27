import { Component } from '@angular/core';

@Component({
  selector: 'invoice-header',
  templateUrl: './invoice-header.component.html',
  styleUrls: ['./invoice-header.component.scss']
})
export class InvoiceHeaderComponent {

  openCreateInvoiceDialog(): void {
    console.log("Create invoice");
    // open 'update-invoice-dialog' without preselection
  }

}
