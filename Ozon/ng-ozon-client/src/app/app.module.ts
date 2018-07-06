import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgModule } from '@angular/core';

import { AppRoutingModule } from './modules/app-routing.module';

import { AppComponent } from './components/app/app.component';
import { NgMatImportsModule } from './modules/ng-mat-imports.module';
import { StorageService } from './services/storage.service';
import { BackgroundSyncService } from './services/background-sync.service';
import { ConfigurationService } from './services/configuration.service';
import { EntitiesUpdaterService } from './services/entities-updater.service';
import { OrderComponent } from './components/order/order.component';
import { FormsModule } from '@angular/forms';
import { GoodComponent } from './components/good/good.component';
import { GoodsPanelComponent } from './components/goods-panel/goods-panel.component';
import { LoggerService } from './services/logger.service';


@NgModule({
  declarations: [
    AppComponent,
    OrderComponent,
    GoodComponent,
    GoodsPanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgMatImportsModule,
    FormsModule
  ],
  providers: [StorageService, BackgroundSyncService, ConfigurationService, EntitiesUpdaterService, LoggerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
