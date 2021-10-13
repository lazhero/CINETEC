import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-movie-managment',
  templateUrl: './movie-managment.component.html',
  styleUrls: ['./movie-managment.component.css']
})
export class MovieManagmentComponent implements OnInit {
  
  addingMovie: boolean = false;
  deletingMovie: boolean = false;
  modifyingMovie: boolean = false;

  movies: any[] = [];

  
    Original_name: string ='';         
    Name: string = '';
    Image: any;          
    Length: string = ''; 
    Main_characters: any = '';            
    Director: string = '';
    Rating: string = '';
            

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<MovieManagmentComponent>) { }

  ngOnInit(): void {}

  selectMovie(event: any) {
    this.Original_name = event.Original_name;
    this.Name = event.Name;
    this.Image = event.Image;
    this.Length = event.Length;
    this.Main_characters = event.Main_characters;
    this.Director = event.Director;
    this.Rating = event.Rating;
  }

  submitModify() {
    if (
      this.Original_name !== '' &&
      this.Image !== undefined &&
      this.Name !== '' &&
      this.Length !== '' &&
      this.Main_characters !== '' &&
      this.Director !== '' &&
      this.Rating !== ''
    ) {
      this.swal.showSuccess(
        'Película modificada',
        'Película modificada con éxito'
      );
    } else {
      this.swal.showError(
        'Error al modificar la película',
        'Los datos ingresados son insuficientes o la película no existe en nuestra base de datos'
      );
    }
  }

  deleteMovie() {
    for (let i = 0; i < this.movies.length; i++) {
      if (this.movies[i].Original_name === this.Original_name) {
        this.movies.splice(i, 1);
        this.swal.showSuccess(
          'Película eliminada',
          'Película eliminada con éxito'
        );
        return;
      }
    }
    this.swal.showError(
      'Error al eliminar película',
      'La película no se encuentra en la base de datos'
    );
  }

  close(): void {
    this.dialogRef.close();
  }


}
