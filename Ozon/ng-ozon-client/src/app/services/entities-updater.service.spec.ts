import { TestBed, inject } from '@angular/core/testing';

import { EntitiesUpdaterService } from './entities-updater.service';

describe('EntitiesUpdaterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EntitiesUpdaterService]
    });
  });

  it('should be created', inject([EntitiesUpdaterService], (service: EntitiesUpdaterService) => {
    expect(service).toBeTruthy();
  }));
});
