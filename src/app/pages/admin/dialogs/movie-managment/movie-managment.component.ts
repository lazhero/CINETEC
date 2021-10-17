import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { DomSanitizer } from '@angular/platform-browser';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-movie-managment',
  templateUrl: './movie-managment.component.html',
  styleUrls: ['./movie-managment.component.css'],
})
export class MovieManagmentComponent implements OnInit {
  addingMovie: boolean = false;
  deletingMovie: boolean = false;
  modifyingMovie: boolean = false;
  get: boolean = false;

  movies: any[] = [];
  actorMovies: any = [];
  actorMoviesString: string = '';
  adultPrice: string = '';
  directorFirstName: string = '';
  directorLastName: string = '';
  directorMiddleName: string = '';
  directorSecondLastName: string = '';
  elderPrice: string = '';
  image: string = '';
  kidPrice: string = '';

  name: string = '';
  originalName: string = '';
  timeLength: string = '';
  currentMovie: any;
  clasificacion: string = '';
  clasificaciones = [
    {
      description: 'SOLO PARA ADULTOS',
      id: 'A1',
    },
    {
      description: 'SOLO PÚBLICO JOVEN',
      id: 'B2',
    },
    {
      description: 'PARA MAYORES DE 5',
      id: 'C3',
    },
  ];

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<MovieManagmentComponent>,
    public backend: BackendService,
    private sanitizer: DomSanitizer
  ) {}
  ngOnInit(): void {
    this.backend.get_request('Admin/Movies', null).subscribe((moviesArray) => {
      moviesArray.forEach(
        async (movie: { image: any; originalName: string }) => {
          await this.getImage(movie.originalName).then((result: any) => {
            movie.image = result;
          });
        }
      );

      this.movies = moviesArray;

      console.log(this.movies);
    });
  }

  selectMovie(event: any) {
    console.log(event);

    this.originalName = event.originalName;
    this.name = event.name;
    this.timeLength = event.timeLength;
    this.actorMovies = event.actorMovies;
    this.directorFirstName = event.directorFirstName;
    this.directorMiddleName = event.directorMiddleName;
    this.directorLastName = event.directorLastName;
    this.directorSecondLastName = event.directorSecondLastName;

    this.currentMovie = event;

    this.adultPrice = event.adultPrice;
    this.elderPrice = event.elderPrice;
    this.kidPrice = event.kidPrice;
  }

  submitAdition() {
    if (
      this.actorMoviesString !== '' &&
      this.adultPrice !== '' &&
      this.directorFirstName !== '' &&
      this.directorLastName !== '' &&
      this.directorMiddleName !== '' &&
      this.directorSecondLastName !== '' &&
      this.elderPrice !== '' &&
      this.image !== undefined &&
      this.kidPrice !== '' &&
      this.name !== '' &&
      this.originalName !== '' &&
      this.timeLength !== ''
    ) {
      const data = {
        image: this.image,
        mov: {
          actorMovies: this.parseActors(this.actorMoviesString),
          adultPrice: this.adultPrice,
          directorFirstName: this.directorFirstName,
          directorLastName: this.directorLastName,
          directorMiddleName: this.directorMiddleName,
          directorSecondLastName: this.directorSecondLastName,
          elderPrice: this.elderPrice,
          image: this.image,
          kidPrice: this.kidPrice,
          movieClassifications: [
            {
              movieOriginalName: this.originalName,
              classificationId: this.clasificacion,
            },
          ],
          name: this.name,
          originalName: this.originalName,
          timeLength: this.timeLength,
        },
      };
      console.log(data);

      const x = Swal.fire({
        imageUrl: 'assets/sloading.gif',
        allowOutsideClick: false,
        showCloseButton: false,
        showConfirmButton: false,
        html: "<div class='text' style='color: white'>Cargando</div>",
        heightAuto: true,
      });
      this.backend.post_request('Admin/Movies', data).subscribe((response) => {
        console.log(response);
        Swal.close();
        this.swal.showSuccess(
          'Película agregada',
          'Película agregada con éxito'
        );
      });
    } else {
      this.swal.showError(
        'Error al agregar la película',
        'Los datos ingresados son insuficientes'
      );
    }
  }

  submitModify() {
    if (
      this.adultPrice !== '' &&
      this.directorFirstName !== '' &&
      this.directorLastName !== '' &&
      this.directorMiddleName !== '' &&
      this.directorSecondLastName !== '' &&
      this.elderPrice !== '' &&
      this.image !== undefined &&
      this.kidPrice !== '' &&
      this.name !== '' &&
      this.originalName !== '' &&
      this.timeLength !== ''
    ) {
      const data = {
        image: this.image,
        mov: {
          actorMovies: [],
          adultPrice: this.adultPrice,
          directorFirstName: this.directorFirstName,
          directorLastName: this.directorLastName,
          directorMiddleName: this.directorMiddleName,
          directorSecondLastName: this.directorSecondLastName,
          elderPrice: this.elderPrice,
          image: this.image,
          kidPrice: this.kidPrice,
          movieClassifications: [
            {
              movieOriginalName: this.originalName,
              classificationId: this.clasificacion,
            },
          ],
          name: this.name,
          originalName: this.originalName,
          timeLength: this.timeLength,
        },
      };
      const x = Swal.fire({
        imageUrl: 'assets/sloading.gif',
        allowOutsideClick: false,
        showCloseButton: false,
        showConfirmButton: false,
        html: "<div class='text' style='color: black'>Cargando</div>",
        heightAuto: true,
      });
      this.backend.put_request('Admin/Movies', data).subscribe((response) => {
        Swal.close();
        this.swal.showSuccess(
          'Película modificada',
          'Película modificada con éxito'
        );
      });
    } else {
      this.swal.showError(
        'Error al modificar la película',
        'Los datos ingresados son insuficientes o la película no existe en nuestra base de datos'
      );
    }
  }

  deleteMovie() {
    this.backend
      .delete_request('Admin/Movies', { movie_org_name: this.originalName })
      .subscribe((result) => {
        this.swal.showSuccess(
          'Película eliminada',
          'Película eliminada con éxito'
        );
      });
  }

  close(): void {
    this.dialogRef.close();
  }

  parseActors(data: string) {
    var resultActors: any[] = [];
    var actorsList = data.split(',');
    actorsList.forEach((actor) => {
      const actorData = actor.split(' ');
      const actorName = {
        actorFirstName: actorData[0] || '',
        actorMiddleName: actorData[1] || '',
        actorLastName: actorData[2] || '',
        actorSecondLastName: actorData[3] || '',
      };
      resultActors.push(actorName);
    });
    return resultActors;
  }

  selectImage(event: any) {
    const me = this;
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = (e) => {
      this.image = reader.result as string;
      this.image = this.image.replace('data:image/png;base64,', '');
    };

    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
  }

  selectClassification(event: any) {
    this.clasificacion = event;
  }

  async getImage(movieName: string) {
    return new Promise((resolve) => {
      this.backend
        .get_request('Images', { path: 'Images\\' + movieName + '.png' })
        .subscribe((result) => {
          resolve({
            value: result,
          });
        });
    });
  }
  fixImage(image: any) {
    if (!image || !image.value) return;
    const fiximage = this.sanitizer.bypassSecurityTrustResourceUrl(
      `data:image/png;base64, ${image.value.fileContents}`
    );
    return fiximage;
  }
}
