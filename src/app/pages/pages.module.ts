import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';

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

import { BillboardComponent } from './billboard/billboard.component';
import { MovieMenuComponent } from './movie-menu/movie-menu.component';
import { MovieTheatersBoardsComponent } from './movie-theaters-boards/movie-theaters-boards.component';
import { PagesComponent } from './pages.component';
import { EmployeeManagmentComponent } from '../admin/admin/dialogs/employee-managment/employee-managment.component';

@NgModule({
  declarations: [
    PagesComponent,
    BillboardComponent,
    MovieMenuComponent,
    MovieTheatersBoardsComponent,

    PagesComponent,
    EmployeeManagmentComponent,
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
