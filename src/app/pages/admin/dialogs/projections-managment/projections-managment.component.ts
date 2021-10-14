import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-projections-managment',
  templateUrl: './projections-managment.component.html',
  styleUrls: ['./projections-managment.component.css']
})
export class ProjectionsManagmentComponent implements OnInit {

  addingProjection: boolean = false;
  deletingProjection: boolean = false;

  projections: any[] = [];
  hours_list: string[] = ["7:00",
                          "8:00",
                          "9:00",
                          "10:00",
                          "11:00",
                          "12:00",
                          "13:00",
                          "14:00",
                          "15:00",
                          "16:00",
                          "17:00",
                          "18:00",
                          "19:00",
                          "20:00"];

  Id_projection: string = '';
  Room: string = '';
  Date: any = new Date(new Date().getTime() - 3888000000);
  Hour: string = '';
  Movie: string = '';
  Movie_theater: string = '';

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<ProjectionsManagmentComponent>) { }

  ngOnInit(): void {
  }


  selectProjections(event: any) {
    this.Id_projection = event.Id_projection
    this.Room = event.Room;
    this.Date = new Date(new Date().getTime() - 3888000000);
    this.Hour = event.Hour;
    this.Movie = event.Movie;
    this.Movie_theater = event.Movie_theater;
  }

  submitModify() {
    if (
      this.Id_projection !== '' &&
      this.Room !== '' &&
      this.Date !== undefined &&
      this.Hour !== '' &&
      this.Movie !== '' &&
      this.Movie_theater !== ''
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
    for (let i = 0; i < this.projections.length; i++) {
      if (this.projections[i].Id_projection === this.Id_projection) {
        this.projections.splice(i, 1);
        this.swal.showSuccess(
          'Proyección eliminada',
          'Proyección eliminada con éxito'
        );
        return;
      }
    }
    this.swal.showError(
      'Error al eliminar la proyección',
      'La proyección no se encuentra en la base de datos'
    );
  }
  close() {
    this.dialogRef.close();
  }
}
