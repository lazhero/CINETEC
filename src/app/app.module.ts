import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DragScrollModule } from 'ngx-drag-scroll';
import { SwalService } from '../app/services/swalService';
import { ClientRegisterComponent } from './src/app/pages/client-register/client-register.component';
@NgModule({
  declarations: [AppComponent, ClientRegisterComponent],
  imports: [
    DragScrollModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
  ],
  exports: [DragScrollModule],
  providers: [SwalService],
  bootstrap: [AppComponent],
})
export class AppModule {}
