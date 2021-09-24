import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { BillboardComponent } from './billboard/billboard.component';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';
import { DragScrollModule } from 'ngx-drag-scroll';
import { MatIconModule } from '@angular/material/icon';
@NgModule({
  declarations: [
    BillboardComponent,
    MovieMenuComponent,
    MovieTheatersBoardsComponent,
  ],
  imports: [MatIconModule, CommonModule, DragScrollModule, PagesRoutingModule],
})
export class PagesModule {}
