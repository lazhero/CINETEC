import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from '../admin/admin/admin/admin.component';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { BillboardComponent } from './billboard/billboard.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';
import { PagesComponent } from './pages.component';

const routes: Routes = [
  {
    path: '',
    component: PagesComponent,
    //canActivate:true,
    children: [
      {
        path: 'movieMenu',
        component: MovieMenuComponent,
      },
      {
        path: 'billboard',
        component: BillboardComponent,
      },
      {
        path: 'movieTheatreSelection',
        component: MovieTheatersBoardsComponent,
      },
      {
        path: '**',
        redirectTo: 'movieTheatreSelection',
      },
      {
        path: '',
        redirectTo: 'movieTheatreSelection',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
