import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IInvoiceList } from '../models/invoice.interface';
import { IInvoiceDetails } from '../models/invoice-details.interface';
import { ICreateInvoice } from '../models/create-invoice.interface';
import { IUpdateInvoice } from '../models/update-invoice.interface';

@Injectable({
  providedIn: 'root'
})
export class InvoiceApiService extends BaseHttpService {

  constructor(private readonly _http: HttpClient) {
    super();
  }

  GetAllInvoices(): Observable<IInvoiceList> {
    return this._http.get<IInvoiceList>(`${this._baseUrl}/invoices`, this.getOptions());
  }

  GetInvoice(id: number): Observable<IInvoiceDetails> {
    return this._http.get<IInvoiceDetails>(`${this._baseUrl}/invoice/${id}`, this.getOptions());
  }

  AddInvoice(invoice: ICreateInvoice): Observable<IInvoiceDetails> {
    const body = { model: invoice };
    return this._http.post<IInvoiceDetails>(`${this._baseUrl}/invoice`, body, this.getOptions());
  }

  DeleteInvoice(id: number): Observable<void> {
    return this._http.delete<void>(`${this._baseUrl}/invoice/${id}`, this.getOptions());
  }

  UpdateInvoice(invoice: IUpdateInvoice): Observable<IInvoiceDetails> {
    const body = { model: invoice };
    return this._http.put<IInvoiceDetails>(`${this._baseUrl}/invoice`, body, this.getOptions());
  }
}
