import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { movieService } from 'src/app/services/movieService';

@Component({
  selector: 'app-billboard',
  templateUrl: './billboard.component.html',
  styleUrls: ['./billboard.component.css'],
})
export class BillboardComponent implements OnInit {
  movies: any[] = [];

  constructor(public router: Router, public mService: movieService) {}

  ngOnInit(): void {
    this.movies.push({
      originalName: 'Sonic',
      name: 'Sonic la espina sangrienta',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Sonic',
      name: 'Sonic la espina sangrienta',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Sonic',
      name: 'Sonic la espina sangrienta',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Sonic',
      name: 'Sonic la espina sangrienta',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Avatar',
      name: 'Avatar en azul',
      image:
        'https://i2.wp.com/hipertextual.com/wp-content/uploads/2016/10/avatar-poster-01.jpg?resize=600%2C886&ssl=1',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Sonic',
      name: 'Sonic la espina sangrienta',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Avatar',
      name: 'Avatar en azul',
      image:
        'https://i2.wp.com/hipertextual.com/wp-content/uploads/2016/10/avatar-poster-01.jpg?resize=600%2C886&ssl=1',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
    this.movies.push({
      originalName: 'Avatar',
      name: 'Avatar en azul',
      image:
        'https://i2.wp.com/hipertextual.com/wp-content/uploads/2016/10/avatar-poster-01.jpg?resize=600%2C886&ssl=1',
      kidPrice: 3000,
      adultPrice: 5000,
      elderPrice: 4500,
      duration: 2.5,
    });
  }
  movieSelected(movie: any): void {
    this.mService.openMovie(movie);
    this.router.navigateByUrl('pages/movieMenu');
  }
}
