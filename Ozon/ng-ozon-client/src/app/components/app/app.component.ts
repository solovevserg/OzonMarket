import { Component } from '@angular/core';
import { StorageService } from '../../services/storage.service';
import { Order } from '../../models/transfer-entities/order';
import { BackgroundSyncService } from '../../services/background-sync.service';
import { ConfigurationService } from '../../services/configuration.service';
import { OrderStates } from '../../models/enums/order-states.enum';

@Component({
  selector: 'ozon-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public get title(): string {
    return this._config.environment.projectName;
  }

  constructor(
    private readonly _config: ConfigurationService,
    private readonly _storage: StorageService,
    private readonly _sync: BackgroundSyncService
  ) { }

  public get orders(): Order[] {
    return this._storage.orders
      .filter(order => order.state !== OrderStates.recieved)
      .sort(order => order instanceof Date ? order.time.getTime() : 0);
  }

  public get recievedOrders(): Order[] {
    return this.orders.filter(order => order.state === OrderStates.recieved);
  }
}
