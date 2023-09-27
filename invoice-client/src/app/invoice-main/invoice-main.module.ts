import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceMainComponent } from './invoice-main.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceHeaderComponent } from './invoice-header/invoice-header.component';
import { InvoiceDetailsComponent } from './invoice-list/invoice-details/invoice-details.component';
import { MatDividerModule } from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  declarations: [
    InvoiceMainComponent,
    InvoiceListComponent,
    InvoiceHeaderComponent,
    InvoiceDetailsComponent
  ],
  imports: [
    MatDividerModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatPaginatorModule,
    MatInputModule,
    MatFormFieldModule
  ]
})
export class InvoiceMainModule { }
