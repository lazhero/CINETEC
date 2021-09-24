import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';

const routes: Routes = [
  {
    path: 'movieMenu',
    component: MovieMenuComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
