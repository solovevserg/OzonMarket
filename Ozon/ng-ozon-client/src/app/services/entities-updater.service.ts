import { Injectable } from '@angular/core';
import { IEntity } from '../models/Interfaces/entity.interface';

@Injectable()
export class EntitiesUpdaterService {

  constructor() { }

  update<T extends IEntity>(target: T, source: T): T {

    Object.keys(target).forEach(key => {
      if (key === 'id' || !(source as Object).hasOwnProperty(key)) {
        return;
      }
      target[key] = JSON.parse(JSON.stringify(source[key]));
    });

    return target;
  }

}
