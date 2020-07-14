import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing'
import {FormsModule,ReactiveFormsModule} from '@angular/forms'
import {HttpClientModule} from '@angular/common/http'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import {SafePipe} from './safe.pipe'
import {InventorItemsComponent} from './InventoryItems/inventory-items.component'
@NgModule({
  declarations: [
    AppComponent,
    SafePipe,
    InventorItemsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
