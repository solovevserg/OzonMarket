import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ConfigurationService } from './configuration.service';
import { OrdersDiff } from '../models/transfer-entities/orders-diff';
import { StorageService } from './storage.service';
import { EntitiesUpdaterService } from './entities-updater.service';
import { LoggerService } from './logger.service';

@Injectable()
export class BackgroundSyncService {


  private _ordersHub: HubConnection;

  constructor(
    private readonly _logger: LoggerService,
    private readonly _config: ConfigurationService,
    private readonly _storage: StorageService,
    private readonly _updater: EntitiesUpdaterService
  ) {
    this._logger.log(`${BackgroundSyncService.name} instance is created and ready to use.`);
    this.establishConnection();
  }

  private establishConnection() {
    const builder = new HubConnectionBuilder();
    builder.withUrl(this._config.environment.backendUrl + '/hubs/orders');
    this._ordersHub = builder.build();

    this._ordersHub.on('recieveDiff', (diff: OrdersDiff) => this.recieveDiff(diff));
    this._ordersHub.on('recieveMessage', (message: string) => this.recieveMessage(message));

    this._ordersHub.onclose(() => this.onClose());

    this._ordersHub.start()
      .then(() => {
        this._logger.log('Connection with orders hub on the server was established');
      })
      .catch(error => {
        this._logger.log(err => this._logger.log('An error occured while establishing the first connection', err));
        this.onClose();
      });
  }

  private onClose() {
    this._logger.log('Connection was closed. Waiting for the new attempt to connect.');
    const onCloseTimer = setInterval(() => {
      this._ordersHub.start()
        .then(() => {
          clearInterval(onCloseTimer);
          this._logger.log('Connection is succesfully reestablished.');
        })
        .catch(err => this._logger.log('An error occured while reestablishing the connection. Waiting for the new attempt...', err));
    }, 1000 * 10);
  }

  recieveDiff(diff: OrdersDiff): void {

    this._logger.log(`Diff was recieved with ${diff.addedOrders.length} added orders`
    + `${diff.deletedOrdersIds.length} deleted orders and ${diff.updatedOrders.length} updated ones.`, diff);

    diff.deletedOrdersIds.forEach(orderId => {
      const orderToDelete = this._storage.orders.find(o => o.id === orderId);
      const indexToDelete = this._storage.orders.indexOf(orderToDelete);
      this._storage.orders.splice(indexToDelete, 1);
    });

    diff.addedOrders.forEach(orderToAdd => {
      if (this._storage.orders.some(o => o.id === orderToAdd.id)) {
        return;
      }
      this._storage.orders.push(orderToAdd);
    });

    diff.updatedOrders.forEach(updateSourceOrder => {
      const orderToUpdate = this._storage.orders.find(o => o.id === updateSourceOrder.id);
      if (!orderToUpdate) {
        return;
      }
      this._updater.update(orderToUpdate, updateSourceOrder);
    });
  }

  private recieveMessage(message: string) {
    this._logger.log(message);
  }
}
