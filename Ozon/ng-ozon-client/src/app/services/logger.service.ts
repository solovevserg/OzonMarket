import { Injectable } from '@angular/core';

@Injectable()
export class LoggerService {

  constructor() { }

  public log(message: any, ...params) {
    console.log(message, ...params);
  }

}
