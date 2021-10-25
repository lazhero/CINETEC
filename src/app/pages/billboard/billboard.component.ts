import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { movieService } from 'src/app/services/movieService';
import { SwalService } from 'src/app/services/swalService';
import { DomSanitizer } from '@angular/platform-browser';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-billboard',
  templateUrl: './billboard.component.html',
  styleUrls: ['./billboard.component.css'],
})
export class BillboardComponent implements OnInit {
  movies: any[] = [];
  cinemaName: string | null | undefined;
  constructor(
    public router: Router,
    public backend: BackendService,
    public mService: movieService,
    private sanitizer: DomSanitizer
  ) {}
  dev: boolean = false;

  async ngOnInit(): Promise<void> {
    const x = Swal.fire({
      imageUrl: 'assets/loading.gif',
      width: '100%',
      background: '#242933',
      allowOutsideClick: false,
      showCloseButton: false,
      showConfirmButton: false,
      html: "<div class='text' style='color: white'>Cargando</div>",
      heightAuto: true,
    });

    const urlParams = new URLSearchParams(window.location.search);

    this.cinemaName = urlParams.get('theater');
    const cinema = {
      cinema_name: this.cinemaName,
    };
    if (!this.cinemaName) return;
    this.backend
      .get_request('Client/Movie', cinema)
      .subscribe((moviesArray) => {
        moviesArray.forEach(
          async (movie: { image: any; originalName: string }) => {
            await this.getImage(movie.image).then((result: any) => {
              movie.image = result;
            });
            Swal.close();
          }
        );

        this.movies = moviesArray;
        if (this.dev) {
          this.movies = this.movies
            .concat(this.movies)
            .concat(this.movies)
            .concat(this.movies)
            .concat(this.movies)
            .concat(this.movies)
            .concat(this.movies);
        }
        //console.log(this.movies);
      });
  }
  movieSelected(movie: any): void {
    this.mService.openMovie(movie);
    localStorage.setItem('movie', movie);
    this.router.navigate(['pages/movieMenu'], {
      queryParams: { theater: this.cinemaName, movie: movie.originalName },
    });
  }
  fixImage(image: any) {
    if (!image || !image.value) return;
    const fiximage = this.sanitizer.bypassSecurityTrustResourceUrl(
      `data:image/png;base64, ${image.value.fileContents}`
    );
    return fiximage;
  }

  async getImage(movImage: string) {
    return new Promise((resolve) => {
      this.backend
        .get_request('Images', { path: movImage })
        .subscribe((result) => {
          resolve({
            value: result,
          });
        });
    });
  }
}
