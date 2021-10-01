import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DragScrollModule } from 'ngx-drag-scroll';
import { HttpClientModule } from '@angular/common/http';

import { SwalService } from '../app/services/swalService';
import { BackendService } from './services/backend-service.service';
@NgModule({
  declarations: [AppComponent],
  imports: [
    DragScrollModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
  ],
  exports: [DragScrollModule],
  providers: [SwalService, BackendService],
  bootstrap: [AppComponent],
})
export class AppModule {}
