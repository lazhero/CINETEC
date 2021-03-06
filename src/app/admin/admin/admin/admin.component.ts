import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router, RouterLink } from '@angular/router';
import { ClientManagmentComponent } from '../dialogs/client-managment/client-managment.component';
import { Covid19ManagmentComponent } from '../dialogs/covid19-managment/covid19-managment.component';
import { EmployeeManagmentComponent } from '../dialogs/employee-managment/employee-managment.component';
import { MovieManagmentComponent } from '../dialogs/movie-managment/movie-managment.component';
import { ProjectionsManagmentComponent } from '../dialogs/projections-managment/projections-managment.component';
import { RoomManagmentComponent } from '../dialogs/room-managment/room-managment.component';
import { TheatherManagmentComponent } from '../dialogs/theather-managment/theather-managment.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  constructor(public dialog: MatDialog, private router: Router) {}

  ngOnInit(): void {}

  openClientManagment() {
    let dialogRef = this.dialog.open(ClientManagmentComponent, {
      width: '450px',
      data: {},
    });
  }

  openEmployeeManagment() {
    let dialogRef = this.dialog.open(EmployeeManagmentComponent, {
      width: '450px',
      data: {},
    });
  }
  openCovid19Managment() {
    let dialogRef = this.dialog.open(Covid19ManagmentComponent, {
      width: '350px',
      data: {},
    });
  }
  openMovieManagment() {
    let dialogRef = this.dialog.open(MovieManagmentComponent, {
      width: '400px',
      data: {},
    });
  }
  openProjectionManagment() {
    let dialogRef = this.dialog.open(ProjectionsManagmentComponent, {
      width: '450px',
      data: {},
    });
  }

  openRoomManagment() {
    let dialogRef = this.dialog.open(RoomManagmentComponent, {
      width: '450px',
      data: {},
    });
  }

  openTheaterManagment() {
    let dialogRef = this.dialog.open(TheatherManagmentComponent, {
      width: '450px',
      data: {},
    });
  }
  logout() {
    this.router.navigateByUrl('auth');
    localStorage.removeItem('admin');
  }
}
