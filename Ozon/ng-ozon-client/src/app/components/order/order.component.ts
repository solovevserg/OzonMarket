import { Component, OnInit, Input } from '@angular/core';
import { Order } from '../../models/transfer-entities/order';

@Component({
  selector: 'ozon-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  @Input()
  public order: Order;

  constructor() { }

  ngOnInit() {
  }

}
