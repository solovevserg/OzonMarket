import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class ConfigurationService {

  constructor() { }

  public get environment() {
    return environment;
  }
}
