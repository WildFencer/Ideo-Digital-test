import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { IInvoice, IInvoiceList } from 'src/app/shared/models/invoice.interface';
import { InvoiceMainService } from '../invoice-main.service';

@Component({
  selector: 'invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.scss']
})
export class InvoiceListComponent implements OnInit {

  constructor(public invoiceService: InvoiceMainService) { }

  ngOnInit(): void {
    this.invoiceService.getAllInvoices();
  }

  openUpdateInvoiceDialog(invoice: IInvoice): void {
    console.log("Update invoice");
    // open 'update-invoice-dialog' with preselection
  }

  deleteInvoice(id: number): void {
    console.log("Delete invoice");
  }

}
