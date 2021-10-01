import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin/admin.component';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { BillboardComponent } from './billboard/billboard.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';
import { ClientRegisterComponent } from './client-register/client-register.component';

const routes: Routes = [
  {
    path: 'movieMenu',
    component: MovieMenuComponent

  },
  {
    path: 'admin',
    component: AdminComponent,
  },
  {
    path: 'billboard',
    component: BillboardComponent 
  },
  {
    path: 'movieTheatreSelection',
    component: MovieTheatersBoardsComponent 
  },
  {
    path: 'clientRegister',
    component: ClientRegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
