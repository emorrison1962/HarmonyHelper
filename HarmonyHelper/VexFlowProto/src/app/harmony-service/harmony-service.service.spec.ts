import { TestBed, inject } from '@angular/core/testing';

import { HarmonyServiceService } from './harmony-service.service';

describe('HarmonyServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HarmonyServiceService]
    });
  });

  it('should be created', inject([HarmonyServiceService], (service: HarmonyServiceService) => {
    expect(service).toBeTruthy();
  }));
});
