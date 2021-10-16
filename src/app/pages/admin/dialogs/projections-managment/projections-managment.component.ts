import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-projections-managment',
  templateUrl: './projections-managment.component.html',
  styleUrls: ['./projections-managment.component.css'],
})
export class ProjectionsManagmentComponent implements OnInit {
  addingProjection: boolean = false;
  deletingProjection: boolean = false;
  theaters: any[] = [];
  rooms: any[] = [];
  movies: any[] = [];
  projections: any[] = [];
  hours_list: string[] = [
    '7:00',
    '8:00',
    '9:00',
    '10:00',
    '11:00',
    '12:00',
    '13:00',
    '14:00',
    '15:00',
    '16:00',
    '17:00',
    '18:00',
    '19:00',
    '20:00',
  ];
  test = [new Date(), new Date()];
  Id_projection: string = '';
  Room: string = '';
  Date: any = new Date(new Date().getTime() - 3888000000);
  initHour: string = '';
  finishHour: string = '';
  Movie: string = '';

  Room_id: string = '';
  Theater_name: string = '';

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<ProjectionsManagmentComponent>,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.backend.get_request('Admin/Sucursales', null).subscribe((cines) => {
      this.theaters = cines;
    });

    this.backend.get_request('Admin/Movies', null).subscribe((movies) => {
      this.movies = movies;
    });
  }

  selectProjections(event: any) {
    this.Id_projection = event.id;
  }
  selectMovie(event: any) {
    this.Movie = event.originalName;

    if (this.Movie != '') {
      const data = {
        Cinema_name: this.Theater_name,
        Movie_name: this.Movie,
      };
      this.backend
        .get_request('Client/Projection', data)
        .subscribe((projections) => {
          console.log(projections);

          this.projections = projections;
        });
    }
  }

  selectRoom(event: any) {
    this.Room_id = event.number;
  }
  selectSucursal($event: any) {
    this.Theater_name = $event;
    console.log(this.Theater_name);

    this.backend
      .get_request('Admin/Sucursales/Room', { cinema_name: this.Theater_name })
      .subscribe((value) => {
        this.rooms = value;
      });
  }

  create() {
    const data = {
      id: 0,
      date: ' 2021-10-15T21:10:11.832Z ',
      initialTime: this.test[0],
      endTime: this.test[1],
      movieOriginalName: this.Movie,
      roomNumber: this.Room_id,
      cinemaName: this.Theater_name,
    };

    this.backend.post_request('Admin/Projections', data).subscribe((value) => {
      this.swal.showSuccess('Éxito', 'Proyección creada con éxito');
    });
  }
  submitModify() {
    if (
      this.Id_projection !== '' &&
      this.Room !== '' &&
      this.Date !== undefined &&
      this.initHour !== '' &&
      this.Movie !== ''
    ) {
      this.swal.showSuccess(
        'Proyección modificada',
        'Proyección modificada con éxito'
      );
    } else {
      this.swal.showError(
        'Error al modificar la proyección',
        'Los datos ingresados son insuficientes o la proyección no existe en nuestra base de datos'
      );
    }
  }

  deleteProjection() {
    this.backend
      .delete_request('Admin/Projections', { proj: this.Id_projection })
      .subscribe((value) => {
        console.log(value);
        this.swal.showSuccess(
          'Proyección eliminada',
          'Proyección eliminada con éxito'
        );
      });
  }

  close() {
    this.dialogRef.close();
  }
}
