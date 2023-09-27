import { Injectable } from '@angular/core';
import { IInvoice, IInvoiceList } from '../shared/models/invoice.interface';
import { InvoiceApiService } from '../shared/services/invoice-api.service';

@Injectable({
  providedIn: 'root'
})
export class InvoiceMainService {
  invoices: Array<IInvoice> = [];

  constructor(private _apiService: InvoiceApiService) { }

  getAllInvoices(): void {
    this._apiService.GetAllInvoices().subscribe((data: IInvoiceList) => {
      this.invoices = data.invoiceList;
    });
  }
}
