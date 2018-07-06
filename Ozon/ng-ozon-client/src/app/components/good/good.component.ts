import { Component, OnInit, Input } from '@angular/core';
import { Good } from '../../models/transfer-entities/good';

@Component({
  selector: 'ozon-good',
  templateUrl: './good.component.html',
  styleUrls: ['./good.component.scss']
})
export class GoodComponent implements OnInit {

  @Input()
  public good: Good;

  constructor() { }

  ngOnInit() {
  }

}
