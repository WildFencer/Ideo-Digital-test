import { TestBed } from '@angular/core/testing';

import { InvoiceMainService } from './invoice-main.service';

describe('InvoiceMainService', () => {
  let service: InvoiceMainService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvoiceMainService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
