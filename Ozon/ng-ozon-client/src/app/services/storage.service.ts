import { Injectable } from '@angular/core';
import { Order } from '../models/transfer-entities/order';

@Injectable()
export class StorageService {

  public readonly orders: Order[] = [];

  constructor() { }

}
