import { Component, OnInit, Input } from '@angular/core';
import { Order } from '../../models/transfer-entities/order';

@Component({
  selector: 'ozon-goods-panel',
  templateUrl: './goods-panel.component.html',
  styleUrls: ['./goods-panel.component.scss']
})
export class GoodsPanelComponent implements OnInit {

  @Input()
  public orders: Order[];

  constructor() { }

  ngOnInit() {
  }

}
