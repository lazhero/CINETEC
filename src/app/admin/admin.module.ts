import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin/admin/admin.component';

import { DragScrollModule } from 'ngx-drag-scroll';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

import { TheatherManagmentComponent } from '../admin/admin/dialogs/theather-managment/theather-managment.component';
import { RoomManagmentComponent } from '../admin/admin/dialogs/room-managment/room-managment.component';
import { MovieManagmentComponent } from '../admin/admin/dialogs/movie-managment/movie-managment.component';
import { Covid19ManagmentComponent } from '../admin/admin/dialogs/covid19-managment/covid19-managment.component';
import { ClientManagmentComponent } from '../admin/admin/dialogs/client-managment/client-managment.component';
import { ProjectionsManagmentComponent } from '../admin/admin/dialogs/projections-managment/projections-managment.component';

@NgModule({
  declarations: [
    AdminComponent,
    TheatherManagmentComponent,
    RoomManagmentComponent,
    MovieManagmentComponent,
    Covid19ManagmentComponent,
    ClientManagmentComponent,
    ProjectionsManagmentComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatMenuModule,
    MatFormFieldModule,
    MatSnackBarModule,
    MatIconModule,
    MatDialogModule,
    CommonModule,
    DragScrollModule,
  ],
})
export class AdminModule {}
