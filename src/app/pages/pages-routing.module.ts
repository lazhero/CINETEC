import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { BillboardComponent } from './billboard/billboard.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';

const routes: Routes = [
  {
    path: 'movieMenu',
    component: MovieMenuComponent

  },
  {
    path: 'billboard',
    component: BillboardComponent 
  },
  {
    path: 'movieTheatreSelection',
    component: MovieTheatersBoardsComponent 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}