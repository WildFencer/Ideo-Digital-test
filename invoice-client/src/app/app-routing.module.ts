import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceMainComponent } from './invoice-main/invoice-main.component';

const routes: Routes = [
  {
    // path: '**',
    // loadChildren: () => import('./invoice-main/invoice-main.module').then(m => m.InvoiceMainModule)
    path: '', pathMatch: 'full', component: InvoiceMainComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
