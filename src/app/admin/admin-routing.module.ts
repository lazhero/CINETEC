import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin/admin.component';

const routes: Routes = [
  {
    path: 'adminC',
    component: AdminComponent,
  },
  {
    path: '**',
    redirectTo: 'adminC',
  },
  {
    path: '',
    redirectTo: 'adminC',
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
