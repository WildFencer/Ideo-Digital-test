import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceHeaderComponent } from './invoice-header.component';

describe('InvoiceHeaderComponent', () => {
  let component: InvoiceHeaderComponent;
  let fixture: ComponentFixture<InvoiceHeaderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvoiceHeaderComponent]
    });
    fixture = TestBed.createComponent(InvoiceHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
