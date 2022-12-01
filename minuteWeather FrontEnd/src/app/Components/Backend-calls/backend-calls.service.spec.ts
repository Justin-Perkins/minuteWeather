import { TestBed } from '@angular/core/testing';

import { BackendCallsService } from './backend-calls.service';

describe('BackendCallsService', () => {
  let service: BackendCallsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BackendCallsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
