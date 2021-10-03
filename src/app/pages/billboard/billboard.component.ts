import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-billboard',
  templateUrl: './billboard.component.html',
  styleUrls: ['./billboard.component.css'],
})
export class BillboardComponent implements OnInit {
  movies: any[] = [];

  constructor(public router: Router) {}

  ngOnInit(): void {
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
    this.movies.push({
      name: 'Prueba1',
      image:
        'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg',
    });
  }
  movieSelected(movieName: any): void {
    this.router.navigateByUrl('pages/movieMenu');
  }
}
