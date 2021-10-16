import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { BillboardComponent } from './billboard/billboard.component';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';
import { DragScrollModule } from 'ngx-drag-scroll';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AdminComponent } from './admin/admin/admin.component';
import { TheatherManagmentComponent } from './admin/dialogs/theather-managment/theather-managment.component';
import { RoomManagmentComponent } from './admin/dialogs/room-managment/room-managment.component';
import { MovieManagmentComponent } from './admin/dialogs/movie-managment/movie-managment.component';
import { Covid19ManagmentComponent } from './admin/dialogs/covid19-managment/covid19-managment.component';
import { ClientManagmentComponent } from './admin/dialogs/client-managment/client-managment.component';
import { ProjectionsManagmentComponent } from './admin/dialogs/projections-managment/projections-managment.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PagesComponent } from './pages.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
@NgModule({
  declarations: [
    PagesComponent,
    BillboardComponent,
    MovieMenuComponent,
    MovieTheatersBoardsComponent,
    AdminComponent,
    TheatherManagmentComponent,
    RoomManagmentComponent,
    MovieManagmentComponent,
    Covid19ManagmentComponent,
    ClientManagmentComponent,
    ProjectionsManagmentComponent,
    PagesComponent,
  ],
  imports: [
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
    PagesRoutingModule,
  ],
  providers: [MatDatepickerModule],
})
export class PagesModule {}
