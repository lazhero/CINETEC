import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
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


  actorMovies:             string = "";
  adultPrice:              string = "";
  directorFirstName:       string = "";
  directorLastName:        string = "";
  directorMiddleName:      string = "";
  directorSecondLastName:  string = "";
  elderPrice:              string = "";
  image:                   any;
  kidPrice:                string = "";
  movieClassifications:    string = "";
  name:                    string = "";
  originalName:            string = "";
  timeLength:              string = "";
            

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<MovieManagmentComponent>,
    public backend: BackendService) { }

  ngOnInit(): void {
    this.backend.get_request("Admin/Movies",null)
    .subscribe(result=>{
      this.movies = result;
      console.log(result);
      
    })
  }

  selectMovie(event: any) {

    this.actorMovies            = event.actorMovies;
    this.adultPrice             = event.adultPrice;
    this.directorFirstName      = event.directorFirstName;
    this.directorLastName       = event.directorLastName;
    this.directorMiddleName     = event.directorMiddleName;
    this.directorSecondLastName = event.directorSecondLastName;
    this.elderPrice             = event.elderPrice;
    this.image                  = event.image;
    this.kidPrice               = event.kidPrice;
    this.movieClassifications   = event.movieClassifications;
    this.name                   = event.name;
    this.originalName           = event.originalName;
    this.timeLength             = event.timeLength;

  }


  submitAdition() {
    if (
      this.actorMovies            !== '' &&
      this.adultPrice             !== '' &&
      this.directorFirstName      !== '' &&
      this.directorLastName       !== '' &&
      this.directorMiddleName     !== '' &&
      this.directorSecondLastName !== '' &&
      this.elderPrice             !== '' &&
      this.image                  !== undefined &&
      this.kidPrice               !== '' &&
      this.movieClassifications   !== '' &&
      this.name                   !== '' &&
      this.originalName           !== '' &&
      this.timeLength             !== ''

    ) {
      const data = {image: this.image,
                    mov:{
                    actorMovies: this.parseActors(this.actorMovies),        
                    adultPrice: this.adultPrice,       
                    directorFirstName:this.directorFirstName,  
                    directorLastName:this.directorLastName,   
                    directorMiddleName:this.directorMiddleName,     
                    directorSecondLastName:this.directorSecondLastName, 
                    elderPrice:this.elderPrice,             
                    image:this.image,                  
                    kidPrice:this.kidPrice,              
                    movieClassifications:[{movieOriginalName:this.originalName,
                      classificationId: this.movieClassifications}],   
                    name:this.name,                   
                    originalName:this.originalName,             
                    timeLength:this.timeLength
          }
        }
      console.log(data);
      
      this.backend.post_request("Admin/Movies",data)
      .subscribe(response=>{
        console.log(response);
        
        this.swal.showSuccess(
          'Película agregada',
          'Película agregada con éxito'
        );
      })
    } else {
      this.swal.showError(
        'Error al agregar la película',
        'Los datos ingresados son insuficientes'
      );
    }
  }

  submitModify() {
    if (
      this.actorMovies            !== '' &&
      this.adultPrice             !== '' &&
      this.directorFirstName      !== '' &&
      this.directorLastName       !== '' &&
      this.directorMiddleName     !== '' &&
      this.directorSecondLastName !== '' &&
      this.elderPrice             !== '' &&
      this.image                  !== undefined &&
      this.kidPrice               !== '' &&
      this.movieClassifications   !== '' &&
      this.name                   !== '' &&
      this.originalName           !== '' &&
      this.timeLength             !== ''

    ) {
      const data = { mov:{
            actorMovies: this.parseActors(this.actorMovies),
            adultPrice: this.adultPrice,   
            directorFirstName:this.directorFirstName,  
            directorLastName:this.directorLastName,   
            directorMiddleName:this.directorMiddleName,     
            directorSecondLastName:this.directorSecondLastName, 
            elderPrice:this.elderPrice,             
            image:this.image,                  
            kidPrice:this.kidPrice,              
            movieClassifications:[{MovieOriginalName:this.originalName,
              ClassificationId: this.movieClassifications}],   
            name:this.name,                   
            originalName:this.originalName,              
            timeLength:this.timeLength
          }, image: this.image
        }
      this.backend.put_request("Admin/Movies",data)
      .subscribe(response=>{
        this.swal.showSuccess(
          'Película modificada',
          'Película modificada con éxito'
        );
      })
    } else {
      this.swal.showError(
        'Error al modificar la película',
        'Los datos ingresados son insuficientes o la película no existe en nuestra base de datos'
      );
    }
  }

  deleteMovie() {
    for (let i = 0; i < this.movies.length; i++) {
      if (this.movies[i].originalName === this.originalName) {
        this.movies.splice(i, 1);

        const data = { mov:{
          actorMovies: this.parseActors(this.movies[i].actorMovies),        
          adultPrice: this.movies[i].adultPrice,         
          director:this.movies[i].director,
          directorFirstName:this.movies[i].directorFirstName,  
          directorLastName:this.movies[i].directorLastName,   
          directorMiddleName:this.movies[i].directorMiddleName,     
          directorSecondLastName:this.movies[i].directorSecondLastName, 
          elderPrice:this.movies[i].elderPrice,             
          image:this.movies[i].image,                  
          kidPrice:this.movies[i].kidPrice,              
          movieClassifications:{MovieOriginalName:this.movies[i].originalName,
                                ClassificationId: this.movies[i].movieClassifications},   
          name:this.movies[i].name,                   
          originalName:this.movies[i].originalName,           
          projections:this.movies[i].projections,            
          timeLength:this.movies[i].timeLength
        }, image: this.movies[i].image
      }
        this.backend.delete_request("Admin/Movies",data);
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

  parseActors(data: string) {
    var resultActors: any[] = [];
    var actorsList=data.split(",");
    actorsList.forEach( actor=>{
      const actorData = actor.split(" ");
      const actorName = {actorFirstName: actorData[0]||"",
                  actorMiddleName: actorData[1]||"",
                  actorLastName: actorData[2]||"",
                  actorSecondLastName: actorData[3]||"",}
      resultActors.push(actorName);
      
    })
    return resultActors;
  }


}