import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PagesComponent } from './pages/pages.component';
import { LoadingComponent } from './pages/loading/loading.component';
import { MovieTheatersBoardComponent } from './pages/movie-theaters-board/movie-theaters-board.component';
import { BillboardComponent } from './pages/billboard/billboard.component';
import { MovieMenuComponent } from './pages/movie-menu/movie-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    LoadingComponent,
    MovieTheatersBoardComponent,
    BillboardComponent,
    MovieMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
