import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ClientRegisterComponent } from '../auth/client-register/client-register.component';

const routes: Routes = [
  {
    path: '',
    //canActivateChild: [SecureInnerPagesGuard],
    children: [
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'clientRegister',
        component: ClientRegisterComponent,
      },
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full',
      },
      {
        path: '**',
        component: LoginComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
